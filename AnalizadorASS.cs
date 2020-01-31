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
        }

        /// <summary>
        ///     METODO QUE ANALIZA UN DIALOGO DE UN ARCHIVO ADVANCE SUBSTATION ALPHA Y EXTRA SUS PROPIEDADES
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="deleteLabel"></param>
        /// <param name="comment_"></param>
        /// <param name="commentOriginal"></param>
        /// <param name="Lenguage"></param>
        /// <returns></returns>
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
                    /////////////////////////////////////////////////////////////////////
                    ///SIGUIMIENTO INICIAL DONDE SE DEFINE LA LINEA DE RECONOCIMIENTO ///
                    ///Y CAMBIOS DE ESTADO CADA QUE SE RECONOCE EL TOKEN SE VUELVE A  ///
                    ///INICIAR DESDE AQUI                                             ///
                    /////////////////////////////////////////////////////////////////////
                    case 0:
                        if (c.CompareTo(':') == 0 || c.CompareTo(' ') == 0)
                        {
                            lexema = "";
                        }
                        else if (c.CompareTo('{') == 0)
                        {
                            estadoActual = 4;
                            lexema += c;
                        }
                        else if (c.CompareTo('\\') == 0)
                        {
                            estadoActual = 1;
                        }
                        else if (char.IsDigit(c))
                        {
                            estadoActual = 2;
                            lexema += c;
                        }
                        else if (c.CompareTo(',') == 0)
                        {
                            if (contadorComas == 3)
                            {
                                agregarToken(lexema, 2, deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                                contadorComas++;
                            }
                            else if (contadorComas == 4)
                            {
                                agregarToken(lexema, 3, deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                                contadorComas++;
                            }
                            else if (contadorComas == 8)
                            {
                                agregarToken(lexema, 7, deleteLabel, comment_, commentOriginal, Lenguage);
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
                    case 1:
                        if (c.CompareTo('N') == 0)
                        {
                            estadoActual = 3;
                        }
                        else
                        {
                           
                            lexema += entrada.ElementAt(i - 1);
                            lexema += c;
                            estadoActual = 3;
                        }
                        break;
                    /////////////////////////////////////////////////////////////////////////
                    ///SEGUIMIENTO DE LOS TIEMPOS, LAYER, Y LAS POSICIONES MARGINALES:    ///
                    ///MARGINL, MARGINR, MARGINVADEMAS DE UNOS CASOS ESPECIALES DEL NOMBRE///
                    /////////////////////////////////////////////////////////////////////////
                    case 2:
                        if (c.CompareTo(',')==0)
                        {
                            if (contadorComas == 0)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, 1, deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 1)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, 8, deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 2)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, 9, deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }  
                            else if (contadorComas == 4)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, 3, deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 5)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, 4, deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 6)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, 5, deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else if (contadorComas == 7)
                            {
                                estadoActual = 0;
                                contadorComas++;
                                agregarToken(lexema, 6, deleteLabel, comment_, commentOriginal, Lenguage);
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
                        break;
                    //////////////////////////////////////////////////////////////////////////////////
                    ///SEGUIMIENTO DE TEXTO, DONDE SE RECONOCE LA PRIMERA PALABRA, TEXTO, NOMBRE,/////
                    ///ESTILOS, ADEMAS DE RECONOCER EL INICIO DE UNA INSTANCIA DE ETIQUETA EX.{\i0}///
                    ///CONSIDERAR QUE DURANTE ESTA ITERACION SE ELIMINAN LOS SALTOS DE LINEAS PARA////
                    ///QUE LA API PUEDA TRADUCIR EL TEXTO COMPLETO SIN CORTES NI INTERRUPCIONES...////
                    //////////////////////////////////////////////////////////////////////////////////
                    case 3:
                        if (entrada.ElementAt(i)==':')
                        {
                            if (lexema.Equals("Dialogue") || lexema.Equals("Comment"))
                            {
                                agregarToken(lexema, 0, deleteLabel, comment_, commentOriginal, Lenguage);
                                estadoActual = 0;
                                lexema = "";
                            }
                            else if (lexema.Equals("Format"))
                            {
                                entrada = entrada.TrimEnd('#');
                                agregarToken(entrada, 12, deleteLabel, comment_, commentOriginal, Lenguage);
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
                                agregarToken(lexema, 11, deleteLabel, comment_, commentOriginal, Lenguage);
                                estadoActual = 0;
                                lexema = "";
                                imprimirToken();
                            }
                        }
                        else if (entrada.ElementAt(i)==',')
                        {                            
                            if (contadorComas > 9)
                            {
                                agregarToken(lexema, 11, deleteLabel, comment_, commentOriginal, Lenguage);
                                estadoActual = 0;
                                lexema = "";
                            }
                            else if (contadorComas == 3)
                            {
                                contadorComas++;
                                agregarToken(lexema, 2, deleteLabel, comment_, commentOriginal, Lenguage);
                                estadoActual = 0;
                                lexema = "";
                            }
                            else if (contadorComas == 4)
                            {
                                contadorComas++;
                                agregarToken(lexema, 3, deleteLabel, comment_, commentOriginal, Lenguage);
                                estadoActual = 0;
                                lexema = "";
                            }
                            else if (contadorComas == 8)
                            {
                                contadorComas++;
                                agregarToken(lexema, 7, deleteLabel, comment_, commentOriginal, Lenguage);
                                estadoActual = 0;
                                lexema = "";
                            }
                            else
                            {
                                lexema += c;
                            }                            
                        }
                        else if (entrada.ElementAt(i)=='{')
                        {                                                       
                            if (contadorComas >= 9)
                            {
                                i--;
                                estadoActual = 0;
                                agregarToken(lexema, 11, deleteLabel, comment_, commentOriginal, Lenguage);
                                lexema = "";
                            }
                            else
                            {
                                lexema += c;
                            }
                        }
                        else if (entrada.ElementAt(i) =='\\')
                        {
                            i--;

                            estadoActual = 0;
                        }
                        else
                        {
                            lexema += c;
                        }
                        break;
                    ////////////////////////////////////////////////////////////////////////////////////
                    ///SEGUIMIENTO DE LAS ETIQUETAS DE MODIFICACION DE TEXTO EX. {\i0}, {\a8}, etc...///
                    ////////////////////////////////////////////////////////////////////////////////////
                    case 4:
                        if (c.CompareTo('}')==0)
                        {
                            lexema += c;
                            agregarToken(lexema, 10, deleteLabel, comment_, commentOriginal, Lenguage);
                            lexema = "";
                            estadoActual = 0;
                        }
                        else
                        {
                            lexema += c;
                        }
                        break;
                }
            }
            return Dialogue_Translate;
        }

        /// <summary>
        /// METODO QUE IMPRIME EN UN CUADRO DE TEXTO EL PROGRESO DE LA TRADUCCION
        /// </summary>
        string dialogueWithout = "", dialogueWithoutTranslate = "", start_Dialogue = "", end_Dialogue="";
        private void imprimirToken()
        {
            Formulario.translateViewText.Text += start_Dialogue +" --> " + end_Dialogue+"\r\n";
            Formulario.translateViewText.Text += dialogueWithout + "\r\n";
            Formulario.translateViewText.Text += dialogueWithoutTranslate + "\r\n\r\n";
            Formulario.translateViewText.SelectionStart = Formulario.translateViewText.Text.Length;
            Formulario.translateViewText.ScrollToCaret();
            dialogueWithout = "";
            dialogueWithoutTranslate = "";
            start_Dialogue = "";
            end_Dialogue = "";
        }


        /// <summary>
        /// METODO QUE VA SUMANDO LAS PROPIEDADES RECONOCIDAS DE UNA LINEA DE DIALOGO ADEMAS DE SER LA ENCARGADA DE REALIZAR 
        /// LA TRADUCCION, TAMBIEN SE HACEN LOS ARREGLOS SEGUN LAS PROPIEDADES MARCADAS DESDE LA INTERFAZ DE USUARIO
        /// </summary>
        /// REFERENCIADOS DE 'tipo'
        /// 0 = Palabra Reservada
        /// 1 = Layer
        /// 2 = Style
        /// 3 = Name
        /// 4 = MarginL
        /// 5 = MarginR
        /// 6 = MarginV
        /// 7 = Effect
        /// 8 = Start
        /// 9 = End
        /// 10 = Propiedades
        /// 11 = Dialogo
        /// 12 = Format
        private void agregarToken(string lexema, int tipo, bool delete_label, bool comment, bool comment_original, string Lenguage)
        {
            switch (tipo)
            {
                case 0:
                    Dialogue_Translate += lexema + ": ";
                    //Console.WriteLine("POR AQUI");
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    Dialogue_Translate += lexema + ",";
                    break;
                case 8:
                    Dialogue_Translate += lexema + ",";
                    start_Dialogue = lexema;
                    break;
                case 9:
                    Dialogue_Translate += lexema + ",";
                    end_Dialogue = lexema;
                    break;
                case 10:
                    if (delete_label)
                    {
                        Dialogue_Translate += "";
                    }
                    else
                    {
                        Dialogue_Translate += lexema;
                    }
                    break;
                case 11:
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
                case 12:
                    Dialogue_Translate = lexema;
                    break;
            }                
        }
    }


}
