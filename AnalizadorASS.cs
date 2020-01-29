using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Traductor_de_Subtitulos
{
    class AnalizadorASS
    {

        string Dialogue_Translate = "";
        TranslatorForm Formulario;
        YandexTranslate yandex = new YandexTranslate();

        public AnalizadorASS(TranslatorForm A) {
            Formulario = A;
            //Formulario.textBox1.Text = "Se instancio la clase pro";
        }

        public string Analizar(string entrada, bool deleteLabel, bool comment_, bool commentOriginal, string Lenguage)
        {
            int estadoActual = 0, contadorComas = 0;
            string lexema = "";
            Dialogue_Translate = "";
            entrada += '#';
            char c;
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada.ElementAt(i);

                switch (estadoActual)
                {
                    case 0:
                        if (c.CompareTo(':')==0 || c.CompareTo(' ')==0)
                        {
                            lexema = "";
                        }
                        else if (c.CompareTo('{')==0)
                        {
                            estadoActual = 4;
                            lexema += c;
                        }
                        else if (char.IsDigit(c))
                        {
                            estadoActual = 2;
                            lexema += c;
                        }
                        else if (c.CompareTo(',')==0)
                        {
                            
                            if (contadorComas == 3)
                            {
                                agregarToken(lexema, "Style", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                                contadorComas++;
                            }
                            else if (contadorComas == 4)
                            {
                                agregarToken(lexema, "Name", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                                contadorComas++;
                            }
                            else if (contadorComas == 8)
                            {
                                agregarToken(lexema, "Effect", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                                contadorComas++;
                            }
                        }
                        else
                        {
                            estadoActual = 3;
                            lexema += c;
                        }
                        break;
                    case 2:
                        if (c.CompareTo(',')==0)
                        {
                            if (contadorComas == 0)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, "Layer", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 1)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, "Start", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 2)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, "End", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }  
                            else if (contadorComas == 4)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, "Name", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 5)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, "MarginL", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 6)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, "MarginR", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 7)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, "MarginV", deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                        }
                        else if (c.CompareTo(':')==0 || c.CompareTo('.')==0)
                        {
                            lexema += c;
                            
                        }
                        else if (char.IsDigit(c))
                        {
                            lexema += c;
                        }
                        /*else
                        {
                            lexema += c;
                            estadoActual = 0;
                        }*/
                        break;
                    case 3:
                        if (entrada.ElementAt(i)==':')
                        {
                            //lexema += c;
                            if (lexema.Equals("Dialogue") || lexema.Equals("Comment"))
                            {
                                agregarToken(lexema, "Palabra Reservada", deleteLabel, comment_, commentOriginal, Lenguage);
                                estadoActual = 0;
                                lexema = "";
                            }
                            else if (lexema.Equals("Format"))
                            {
                                entrada = entrada.TrimEnd('#');
                                agregarToken(entrada, "Format", deleteLabel, comment_, commentOriginal, Lenguage);
                                //imprimirToken();
                                estadoActual = 0;
                                lexema = "";
                                i = entrada.Length;
                            }
                            else
                            {
                                lexema += c;
                            }
                        }
                        else if (entrada.ElementAt(i)=='#')
                        {
                            if (!lexema.Equals(""))
                            {
                                agregarToken(lexema, "Dialogo", deleteLabel, comment_, commentOriginal, Lenguage);
                                estadoActual = 0;
                                lexema = "";
                                imprimirToken();
                            }
                        }
                        else if (entrada.ElementAt(i)==',')
                        {
                            /*lexema += c;                           
                            if (lexema.Equals("Dialogue") || lexema.Equals("Format") || lexema.Equals("Comment"))
                            {
                                agregarToken(lexema, "Palabra Reservada");
                                estadoActual = 0;
                                lexema = "";
                            }
                            else 
                            {*/
                                if (contadorComas > 9)
                                {
                                    agregarToken(lexema, "Dialogo", deleteLabel, comment_, commentOriginal, Lenguage);
                                    estadoActual = 0;
                                    lexema = "";
                                }
                                else if (contadorComas == 3)
                                {
                                    contadorComas++;
                                    agregarToken(lexema, "Style", deleteLabel, comment_, commentOriginal, Lenguage);
                                    estadoActual = 0;
                                    lexema = "";
                                }
                                else if (contadorComas == 4)
                                {
                                    contadorComas++;
                                    agregarToken(lexema, "Name", deleteLabel, comment_, commentOriginal, Lenguage);
                                    estadoActual = 0;
                                    lexema = "";
                                }
                                else if (contadorComas == 8)
                                {
                                    contadorComas++;
                                    agregarToken(lexema, "Effect", deleteLabel, comment_, commentOriginal, Lenguage);
                                    estadoActual = 0;
                                    lexema = "";
                                }
                                else
                                {
                                    lexema += c;
                                }
                            //}
                        }
                        else if (entrada.ElementAt(i)=='{')
                        {
                            i--;                            
                                if (contadorComas >= 9)
                                {
                                    estadoActual = 0;
                                    agregarToken(lexema, "Dialogo", deleteLabel, comment_, commentOriginal, Lenguage);
                                    estadoActual = 0;
                                    lexema = "";
                                }
                                else if (contadorComas == 8)
                                {
                                    estadoActual = 0;
                                    agregarToken(lexema, "Effect", deleteLabel, comment_, commentOriginal, Lenguage);
                                    estadoActual = 0;
                                    lexema = "";
                                }
                                else if (contadorComas == 3)
                                {
                                    estadoActual = 0;
                                    agregarToken(lexema, "Style", deleteLabel, comment_, commentOriginal, Lenguage);
                                    estadoActual = 0;
                                    lexema = "";
                                }
                                else if (contadorComas == 4)
                                {
                                    estadoActual = 0;
                                    agregarToken(lexema, "Name", deleteLabel, comment_, commentOriginal, Lenguage);
                                    estadoActual = 0;
                                    lexema = "";
                                }
                                else
                                {
                                    Console.WriteLine("Hubo un error");
                                }
                            
                        }
                        else
                        {
                            lexema += c;
                            //Console.WriteLine(lexema);
                        }
                        break;
                    case 4:
                        if (c.CompareTo('}')==0)
                        {
                            lexema += c;
                            agregarToken(lexema, "Propiedades", deleteLabel, comment_, commentOriginal, Lenguage);
                            lexema = "";
                            estadoActual = 0;
                        }
                        else
                        {
                            lexema += c;
                        }
                        break;

                    default:

                        break;
                }
            }
            //Console.WriteLine("Retorna: "+Dialogue_Translate);
            return Dialogue_Translate;
        }


        string dialogueWithout = "", dialogueWithoutTranslate = "", start_Dialogue = "", end_Dialogue="";
        private void imprimirToken()
        {
            Formulario.translateViewText.Text += start_Dialogue +" - " + end_Dialogue+"\r\n";
            Formulario.translateViewText.Text += dialogueWithout + "\r\n";
            Formulario.translateViewText.Text += dialogueWithoutTranslate + "\r\n\r\n";
            Formulario.translateViewText.SelectionStart = Formulario.translateViewText.Text.Length;
            Formulario.translateViewText.ScrollToCaret();
            dialogueWithout = "";
            dialogueWithoutTranslate = "";
            start_Dialogue = "";
            end_Dialogue = "";
        }



        private void agregarToken(string lexema, string tipo, bool delete_label, bool comment, bool comment_original, string Lenguage)
        {
            switch (tipo)
            {
                case "Palabra Reservada":
                    Dialogue_Translate += lexema + ": ";
                    //Console.WriteLine("POR AQUI");
                    break;
                case "Layer":
                case "Style":
                case "Name":
                case "MarginL":
                case "MarginR":
                case "MarginV":
                case "Effect":
                    Dialogue_Translate += lexema + ",";
                    break;
                case "Start":
                    Dialogue_Translate += lexema + ",";
                    start_Dialogue = lexema;
                    break;
                case "End":
                    Dialogue_Translate += lexema + ",";
                    end_Dialogue = lexema;
                    break;
                case "Propiedades":
                    if (delete_label)
                    {
                        Dialogue_Translate += "";
                    }
                    else
                    {
                        Dialogue_Translate += lexema;
                    }
                    break;
                case "Dialogo":
                    string temp = yandex.Translation(lexema, Lenguage); 
                    dialogueWithout += lexema;
                    dialogueWithoutTranslate += temp;
                    if (comment)
                    {
                        if (comment_original)
                        {
                            
                            Dialogue_Translate += temp + " {" + lexema + "}";
                        }
                        else
                        {
                            Dialogue_Translate += lexema + " {" + temp + "}";
                        }
                    }
                    else
                    {
                        Dialogue_Translate += temp;
                    }
                    break;
                case "Format":
                    Dialogue_Translate = lexema;
                    break;
            }                
        }
    }


}
