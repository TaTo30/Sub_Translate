using System;
using System.Text;
using System.Collections.Specialized;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Traductor_de_Subtitulos
{
    class YandexTranslate
    {
        public string Translation(string text_to_translate, string from_to)
        {
            using (var webClient = new WebClient())
            {
                var request = new NameValueCollection();
                request["text"] = text_to_translate; // text to translate
                request["lang"] = from_to; // target language
                request["key"] = "trnsl.1.1.20191219T003905Z.bfc053c4064dede1.dc855f1045fa92245ad4f948bcdc2018fa0fd6cd";

                try
                {
                    var response = webClient.UploadValues("https://translate.yandex.net/api/v1.5/tr.json/translate", "POST", request);
                    string responseInString = Encoding.UTF8.GetString(response);
                    var rootObject = JsonConvert.DeserializeObject<Translation>(responseInString);
                    return rootObject.text[0];

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR!!! " + ex.Message);
                    return ex.Message;
                    throw;
                }

            }
        }
    }

    class Translation
    {
        public int code { get; set; }
        public string lang { get; set; }
        public List<string> text { get; set; }
    }
}
