using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traductor_de_Subtitulos
{
    class AnalizadorSRT
    {
        string Dialogue_Translate = "";
        YandexTranslate yandex = new YandexTranslate();
        TranslatorForm Formulario;

        public AnalizadorSRT(TranslatorForm A)
        {
            Formulario = A;
        }
        /// <summary>
        /// ES UN ARCHIVO SRT LA VERDAD NO HAY MUCHO QUE SE DEBA HACER ;V, LO DE ABAJO SIMPLEMENTE TRADUCE LAS LINEAS QUE ENTRAN E IMPRIME
        /// EN UN CUADRO DE TEXTO EL PROGRESO DE LA TRADUCCION, ¿FACIL, NO? xD
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="FromTo"></param>
        /// <returns></returns>
        public string Analizar(string entrada, string FromTo)
        {
            Dialogue_Translate = yandex.Translation(entrada, FromTo);
            Formulario.translateViewText.Text += entrada + "\r\n";
            Formulario.translateViewText.Text += Dialogue_Translate + "\r\n\r\n";
            Formulario.translateViewText.SelectionStart = Formulario.translateViewText.Text.Length;
            Formulario.translateViewText.ScrollToCaret();
            return Dialogue_Translate;
        }

    }
}
