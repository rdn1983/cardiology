using System;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace Cardiology
{
    class Morpher
    {
        private static readonly String url = "https://ws3.morpher.ru/russian/declension?s=";

        /*
         Метод пытается просклонять переданное имя (это может быть ФИО), обращаясь к веб-сервису Морфер
         */
        public String ToGenitive(String name)
        {
            String uri = String.Format(url, name);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            System.Console.WriteLine(responseString);

            XDocument xDocument = XDocument.Parse(responseString);
            return xDocument.Root.Element("Р").Value;
        }
    }
}
