using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace CSharpUtil.Services
{
    public class WebService
    {
        public string Url { get; set; }
        public string MethodName { get; set; }
        public Dictionary<string, string> Params = new Dictionary<string, string>();
        public XDocument ResultXml;
        public string ResultString;

        public WebService()
        {

        }

        public WebService(string url, string methodName)
        {
            Url = url;
            MethodName = methodName;
        }

        /// <summary>
        /// Invokes service
        /// </summary>
        public void Invoke()
        {
            Invoke(false);
        }

        /// <summary>
        /// Invokes service
        /// </summary>
        /// <param name="encode">Added parameters will encode? (default: true)</param>
        public void Invoke(bool encode)
        {
            var soapStr =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
              <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                 xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                 xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                 <soap:Body>
                     <{0} xmlns=""http://tempuri.org/"">
                      {1}
                    </{0}>
                 </soap:Body>
              </soap:Envelope>";

            var req = (HttpWebRequest)WebRequest.Create(Url);
            req.Headers.Add("SOAPAction", "\"http://tempuri.org/" + MethodName + "\"");
            req.ContentType = "text/xml;charset=\"utf-8\"";
            req.Accept = "text/xml";
            req.Method = "POST";

            using (var stm = req.GetRequestStream())
            {
                var postValues = "";
                foreach (var param in Params)
                {
                    if (encode)
                        postValues += string.Format("<{0}>{1}</{0}>", HttpUtility.UrlEncode(param.Key), HttpUtility.UrlEncode(param.Value));
                    else
                        postValues += string.Format("<{0}>{1}</{0}>", param.Key, param.Value);
                }

                soapStr = string.Format(soapStr, MethodName, postValues);
                using (var stmw = new StreamWriter(stm))
                {
                    stmw.Write(soapStr);
                }
            }

            using (var responseReader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                var result = responseReader.ReadToEnd();
                ResultXml = XDocument.Parse(result);
                ResultString = result;
            }
        }


    }
}


/************************************************************
--- Exemplo de uso da classe
*************************************************************
* 
WebService ws = new WebService("service_url", "method_name");
ws.Params.Add("param1", "value_1");
ws.Params.Add("param2", "value_2");
ws.Invoke();

*************************************************************/
