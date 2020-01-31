using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;


namespace Traductor_de_Subtitulos
{
    public partial class TranslatorForm : Form
    {
        string open_path = "";
        AnalizadorASS scanASS;
        AnalizadorSRT scanSRT;
        BackgroundWorker background = new BackgroundWorker();

        public TranslatorForm()
        {
            InitializeComponent();
            scanASS = new AnalizadorASS(this);
            scanSRT = new AnalizadorSRT(this);
        }

        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /*LOS SIGUIENTES METODOS CORRESPONDEN A UN PROCESO EN SEGUNDO PLANO QUE SE ENCARGARA DE TRADUCIR EL ARCHIVO INGRESADO POR EL USUARIO
        /*ES AUTOEXPLICATIVO ASI QUE NO DEFINIRÉ MAYOR COSA ;D
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        private void translateButton_event(object sender, EventArgs e)
        {
            translateButton.Enabled = false;
            optionGroupBox.Enabled = false;
            progressBar.Value = 1;
            background.DoWork += new DoWorkEventHandler(background_DoWork);
            background.RunWorkerCompleted += new RunWorkerCompletedEventHandler(background_RunWorkerCompleted);          
            background.RunWorkerAsync();
        }

        void background_DoWork(object sender, DoWorkEventArgs e)
        {
            System.IO.StreamReader lector = new System.IO.StreamReader(open_path);
            System.IO.StreamWriter redactor = new System.IO.StreamWriter(savePathTextbox.Text);
            var taskbar = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;
            string line = lector.ReadLine(), result = "";
            int readLine_counter = -1, percent;
            pictureBox1.Image = global::Traductor_de_Subtitulos.Properties.Resources.tenor1;            
            ;
            
            switch (System.IO.Path.GetExtension(open_path))
            {
                case ".ass":
                case ".ssa":
                    bool event_section = false;
                    while (line != null)
                    {
                        if (event_section)
                        {
                            readLine_counter++;
                            result += scanASS.Analizar(line, label_check.Checked, comment_check.Checked, comment_original.Checked, FromTo(comboBox1.SelectedIndex, comboBox2.SelectedIndex)) + "\r\n";
                            progressBar.PerformStep();
                            percent = (int)(((double)progressBar.Value / (double)progressBar.Maximum) * 100);
                            translateCounterLabelPercent.Text = percent + "%";
                            translateCounterLabel.Text = readLine_counter.ToString();
                            taskbar.SetProgressValue(progressBar.Value, progressBar.Maximum);
                            line = lector.ReadLine();
                        }
                        else
                        {
                            result += line + "\r\n";
                            if (line.Equals("[Events]"))
                            {
                                event_section = true;
                            }
                            line = lector.ReadLine();
                        }
                    }
                    break;
                case ".srt":
                    int number;
                    string translate;
                    while (line != null)
                    {
                        if (Int32.TryParse(line, out number))
                        {
                            readLine_counter++;
                            if (number == readLine_counter)
                            {
                                translateViewText.Text += "\r\n";
                                result += "\r\n"+ line + "\r\n";
                                line = lector.ReadLine();
                                translateViewText.Text += line + "\r\n";
                                result += line + "\r\n";
                                line = lector.ReadLine();
                                progressBar.PerformStep();
                                percent = (int)(((double)progressBar.Value/(double)progressBar.Maximum) * 100);
                                translateCounterLabelPercent.Text = percent + "%";
                                translateCounterLabel.Text = readLine_counter.ToString();
                                taskbar.SetProgressValue(progressBar.Value, progressBar.Maximum);
                            }

                        }
                        else
                        {
                            if (line != "")
                            {
                                translateViewText.Text += line + "\r\n";
                                translate = scanSRT.Analizar(line, FromTo(comboBox1.SelectedIndex, comboBox2.SelectedIndex));
                                translateViewText.Text += translate + "\r\n";
                                result += translate +"\r\n";
                            }
                            line = lector.ReadLine();
                        }
                    }
                    break;
            }
            redactor.Write(result);
            redactor.Close();
            lector.Close();

        }
        void background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var taskbar = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;
            translateButton.Enabled = true;
            optionGroupBox.Enabled = true;
            translateCounterLabelPercent.Text = "100%";            
            taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);            
            pictureBox1.Image = global::Traductor_de_Subtitulos.Properties.Resources.tenor;
            Console.WriteLine("Done!");
        }


        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /*METODOS DE ARCHIVO!!! ENTIENDEN?, ABRIR Y GUARDAR ARCHIVOS NO HAY MUCHA DIFICULTAD, ES BASTANTE SENCILLO, SALVO EN EL DE ABRIR   */
        /* QUE DECIDÍ METER AHI EL EXTRACTOR Y CONTADOR DE LINEAS, QUE LO MEJOR SERIA HACERLO EN UN METODO APARTE.... PERO FUNCIONA GG (LO */
        /* HARÉ OTRO DIA :V)                                                                                                               */
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        private void saveFileButton_event(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = savePathTextbox.Text;
            saveFileDialog.Filter = "Advanced SubStation Alpha (*.ass) |*.ass|SubRip (*.srt)|*.srt|Todos los Archivos (*.*)|*.*";
            saveFileDialog.Title = "Directorio";
            saveFileDialog.FileName = System.IO.Path.GetFileName(savePathTextbox.Text);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                savePathTextbox.Text = saveFileDialog.FileName;
            }
        }

       

        private void openFileButton_click(object sender, EventArgs e)
        {
            int total_lineas = -1;
            bool seccionEventos = false;
            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.Filter = "Advanced SubStation Alpha (*.ass) |*.ass|SubRip (*.srt) |*.srt|Todos los Archivos (*.*)|*.*";
            abrirArchivo.FilterIndex = 3;
            abrirArchivo.InitialDirectory = "C://";
            abrirArchivo.Multiselect = false;
            abrirArchivo.Title = "Selecciona un archivo de subtitulos";
            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader lector = new System.IO.StreamReader(abrirArchivo.FileName);
                string line = lector.ReadLine();
                switch (System.IO.Path.GetExtension(abrirArchivo.FileName))
                {
                    case ".ass":
                    case ".ssa":
                        while (line != null)
                        {
                            if (seccionEventos)
                            {
                                total_lineas += 1;
                                line = lector.ReadLine();
                            }
                            else
                            {
                                if (line.Equals("[Events]"))
                                {
                                    seccionEventos = true;
                                }
                                line = lector.ReadLine();
                            }
                        }
                        break;
                    case ".srt":
                        int number;
                        while (line != null)
                        {
                            if (Int32.TryParse(line, out number))
                            {
                                total_lineas++;
                                if (number == total_lineas)
                                {
                                    line = lector.ReadLine();
                                    line = lector.ReadLine();
                                }

                            }
                            else
                            {
                                if (line != "")
                                {
                                    Console.WriteLine("Linea: " + line);
                                }                                
                                line = lector.ReadLine();
                            }
                        }
                        break;
                    default:
                        break;
                }

                lector.Close();
                translateViewText.Text = "";               
                translateCounterLabelPercent.Text = "0%";
                open_path = abrirArchivo.FileName;
                progressBar.Maximum = total_lineas;
                this.fileData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                fileData.Rows[0].Cells[0].Value = System.IO.Path.GetFileNameWithoutExtension(abrirArchivo.FileName); ;
                fileData.Rows[0].Cells[1].Value = total_lineas;
                fileData.Rows[0].Cells[2].Value = abrirArchivo.FileName;
                savePathTextbox.Text = System.IO.Path.GetDirectoryName(abrirArchivo.FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(abrirArchivo.FileName) + " (1)" + System.IO.Path.GetExtension(abrirArchivo.FileName); ;
            }
        }




        /*---------------------------------------------------------------------------------------------------------------------------------*/
        /*¡¡¡METODOS DE INTERFAZ!!! YA SABEN MODIFICAR LOS PARAMETROS DE UNOS CONTROLES PARA QUE SE VEAN BONITOS Y ALGUNAS FUNCIONALIDADES */
        /* VARIAS, ME DA PEREZA EXPLICAR CADA COSA IGUAL SI SE DETIENEN A LEER EL CODIGO ENTENDERAN DE QUE VA CADA COSA ASI QUE NO PROBLEM */
        /*---------------------------------------------------------------------------------------------------------------------------------*/

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            switch (textCommentGroupBox.Enabled)
            {
                case true:
                    textCommentGroupBox.Enabled = false;
                    break;
                case false:
                    textCommentGroupBox.Enabled = true;
                    break;
            }
        }
        private void TranslatorForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            foreach (DataGridViewColumn item in fileData.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
        }

        /// REFERENCIADOS DE 'from' y 'to'
        /// 0 = Ingles
        /// 1 = Español
        /// 2 = Frances
        /// 3 = Italiano
        /// 4 = Japones
        /// 5 = Chino
        private string FromTo(int from, int to)
        {
            string apiRequestLenguage = "";
            switch (from)
            {
                case 0:
                    apiRequestLenguage += "en-";
                    break;
                case 1:
                    apiRequestLenguage += "es-";
                    break;
                case 2:
                    apiRequestLenguage += "fr-";
                    break;
                case 3:
                    apiRequestLenguage += "it-";
                    break;
                case 4:
                    apiRequestLenguage += "ja-";
                    break;
                case 5:
                    apiRequestLenguage += "zh-";
                    break;
            }
            switch (to)
            {
                case 0:
                    apiRequestLenguage += "en";
                    break;
                case 1:
                    apiRequestLenguage += "es";
                    break;
                case 2:
                    apiRequestLenguage += "fr";
                    break;
                case 3:
                    apiRequestLenguage += "it";
                    break;
                case 4:
                    apiRequestLenguage += "ja";
                    break;
                case 5:
                    apiRequestLenguage += "zh";
                    break;
            }
            return apiRequestLenguage;
        }


    }

}
