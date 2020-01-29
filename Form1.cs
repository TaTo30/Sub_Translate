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
        string open_path = "", save_path = "", File_name = "";

        TranslatorForm Formulario;
        AnalizadorASS scan;




        public TranslatorForm()
        {
            InitializeComponent();
            Formulario = this;
            scan = new AnalizadorASS(Formulario);
        }



        private void translateButton_event(object sender, EventArgs e)
        {
            translateButton.Enabled = false;
            optionGroupBox.Enabled = false;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        { 

            pictureBox1.Image = global::Traductor_de_Subtitulos.Properties.Resources.tenor1;
            var taskbar = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;
            System.IO.StreamReader lector = new System.IO.StreamReader(open_path);
            bool event_section = false;
            string line = lector.ReadLine(), result = "";
            int readLine_counter = -1, percent=0;
            while (line != null)
            {
                if (event_section)
                {
                    readLine_counter++;
                    result += scan.Analizar(line, label_check.Checked, comment_check.Checked, comment_original.Checked, FromTo(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString())) + "\r\n";
                    progressBar.PerformStep();
                    translateCounterLabel.Text = readLine_counter.ToString();
                    percent = (int)(((double)progressBar.Value / (double)progressBar.Maximum) * 100);
                    //progressBar.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar.Width / 2 - 10, progressBar.Height / 2 - 7));
                    translateCounterLabelPercent.Text = percent + "%";
                    taskbar.SetProgressValue(progressBar.Value, progressBar.Maximum);
                    line = lector.ReadLine();
                }
                else
                {
                    //redactor.WriteLine(line + "\r\n");
                    result += line + "\r\n";
                    if (line.Equals("[Events]"))
                    {
                        event_section = true;
                    }
                    line = lector.ReadLine();
                }
            }
            lector.Close();
            System.IO.StreamWriter redactor = new System.IO.StreamWriter(savePathTextbox.Text);
            redactor.Write(result);
            redactor.Close();
            
        }


        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            translateButton.Enabled = true;
            optionGroupBox.Enabled = true;
            translateCounterLabelPercent.Text = "100%";
            var taskbar = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;
            taskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
            Console.WriteLine("Done!");
            pictureBox1.Image = global::Traductor_de_Subtitulos.Properties.Resources.tenor;
            
        }
        private void saveFileButton_event(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = save_path;
            saveFileDialog.Filter = "Advanced SubStation Alpha (*.ass; *.ssa) | *.ass; *.ssa";
            saveFileDialog.Title = "Directorio";
            saveFileDialog.FileName = System.IO.Path.GetFileName(save_path);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                savePathTextbox.Text = saveFileDialog.FileName;
            }
        }

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

        private void openFileButton_click(object sender, EventArgs e)
        {
            int total_lineas = 0;
            bool seccionEventos = false;
            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.Filter = "Advanced SubStation Alpha (*.ass; *.ssa) | *.ass; *.ssa";
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
                                Console.WriteLine(line);
                                line = lector.ReadLine();
                            }
                        }
                        break;
                    default:
                        break;
                }

                lector.Close();
                translateViewText.Text = "";
                progressBar.Value = 1;
                translateCounterLabelPercent.Text = "0%";
                open_path = abrirArchivo.FileName;
                save_path = System.IO.Path.GetDirectoryName(abrirArchivo.FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(abrirArchivo.FileName) + " (1)" + System.IO.Path.GetExtension(abrirArchivo.FileName);
                File_name = System.IO.Path.GetFileNameWithoutExtension(abrirArchivo.FileName);
                this.fileData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                progressBar.Maximum = total_lineas;
                fileData.Rows[0].Cells[0].Value = File_name;
                fileData.Rows[0].Cells[1].Value = total_lineas;
                fileData.Rows[0].Cells[2].Value = open_path;
                savePathTextbox.Text = save_path;
            }
        }

        private void FileData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private string FromTo(string from, string to)
        {
            string apiRequestLenguage = "";
            switch (from)
            {
                case "Ingles":
                    apiRequestLenguage += "en-";
                    break;
                case "Español":
                    apiRequestLenguage += "es-";
                    break;
                case "Francés":
                    apiRequestLenguage += "fr-";
                    break;
                case "Italiano":
                    apiRequestLenguage += "it-";
                    break;
                case "Japonés":
                    apiRequestLenguage += "ja-";
                    break;
                case "Chino":
                    apiRequestLenguage += "zh-";
                    break;
            }
            switch (to)
            {
                case "Ingles":
                    apiRequestLenguage += "en";
                    break;
                case "Español":
                    apiRequestLenguage += "es";
                    break;
                case "Francés":
                    apiRequestLenguage += "fr";
                    break;
                case "Italiano":
                    apiRequestLenguage += "it";
                    break;
                case "Japonés":
                    apiRequestLenguage += "ja";
                    break;
                case "Chino":
                    apiRequestLenguage += "zh";
                    break;
            }
            return apiRequestLenguage;
        }


    }

}
