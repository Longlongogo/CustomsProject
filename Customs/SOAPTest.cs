using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace ConsoleApp1
{
    static class SOAPTest
    {
        public static void CallWebService(string qq)
        {
            var _url = "http://www.webxml.com.cn/webservices/qqOnlineWebService.asmx";
            var _action = "http://WebXml.com.cn/qqCheckOnline";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(qq);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                Console.WriteLine(soapResult);
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(string qq)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            string soapXml = @"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema""><SOAP-ENV:Body><qqCheckOnline xmlns=""http://WebXml.com.cn/""><qqCode>qq_Code</qqCode></qqCheckOnline></SOAP-ENV:Body></SOAP-ENV:Envelope>";
            soapEnvelop.LoadXml(soapXml.Replace("qq_Code", qq));
            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        public static void test()
        {
            string[] qq = { "49", "4941", "4949252", "494925223", "494925223", "494925223", "494925223" };
            foreach (var qc in qq)
                SOAPTest.CallWebService(qc);
            Console.ReadKey();
        }
    }
}
