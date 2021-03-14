using JarvisGoogleAPI.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JarvisGoogleAPI.Controller.Convert
{
    public class Recognizer
    {
        public string RecognizeTextFromWav()
        {
            WebRequest request = WebRequest.Create(Config.GoogleAPI);
            //
            request.Method = "POST";
            byte[] byteArray = File.ReadAllBytes(Config.AudioFileName);
            request.ContentType = $"audio/l16; rate={Config.Rate}"; //"16000";
            request.ContentLength = byteArray.Length;
            request.GetRequestStream().Write(byteArray, 0, byteArray.Length);


            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(response.GetResponseStream());
            // Read the content.


            string strtrs = reader.ReadToEnd();
            var rg = new Regex(@"transcript" + '"' + ":" + '"' + "([A-Z, А-Я, a-z,а-я, ,0-9]*)");
            var result = rg.Match(strtrs).Groups[1].Value; //распознанный текст
            //label1.Text = result;

            //label1.Text = strtrs;
            // Clean up the streams.
            reader.Close();
            response.Close();

            return result;
        }
    }
}
