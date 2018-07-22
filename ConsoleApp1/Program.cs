using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ConsoleApp1.Weather;
using ConsoleApp1.Utility;
using ConsoleApp1.BLL;
using ConsoleApp1.Model;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using ConsoleApp1.Test;
using System.Xml.Serialization;
using System.Collections;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlNamespaceTest.SerializeObject("XmlNamespaces.xml");

            //SerializeObject("FirstDoc.xml");
            //DeserializeObject("FirstDoc.xml");
            //Test3();
            //Test2();

            //ModelConfig modelConfig = ModelConfig.GetInstance();
            //string str = XmlHelper.Serializer(typeof(ModelConfig), modelConfig);
            //ModelConfig modelConfig2 = (ModelConfig)XmlHelper.Deserialize(typeof(ModelConfig), str);
            //Console.WriteLine(modelConfig2.LoginName);

            //ZipHelper.CreateZip(@"C:\Project\Test\ConsoleApp1\ConsoleApp1\XSD", @"C:\Project\Test\ConsoleApp1\ConsoleApp1\XSD.zip");
            //CertTest();
            //Console.WriteLine(ModelGlobalConfig.LoginName);
            //Console.WriteLine(ModelGlobalConfig.LoginPassword_Ciphertext);
            //SOAPTest.test();
            //SoapTest();
            //getSum1();
            //Weather.WeatherWebService weatherWebServiceSoap = new WeatherWebService();
            //string[] listResult = weatherWebServiceSoap.getSupportCity("山东");
            //foreach (string result in listResult)
            //{
            //    Console.WriteLine(result);
            //}
            Console.ReadLine();
        } 
        private static void Test3()
        { 
            //xsd验证xml文件
            try
            {
                XmlHelper.Validate(@"C:\chenglong\Project\报关项目文档\海关跨境统一版系统企业对接报文规范\海关跨境统一版系统企业对接报文规范（试行）\样例报文\进口样例\CEB311Message.xml", @"C:\chenglong\Project\报关项目文档\海关跨境统一版系统企业对接报文规范\海关跨境统一版系统企业对接报文规范（试行）\xsd\出口业务节点报文.xsd");
                Console.WriteLine("Successed!");
            }
            catch
            {
                Console.WriteLine("Failed!");
            }
        }
        public static void SerializeObject(string filename)
        {
            // Create the XmlSerializer.
            XmlSerializer s = new XmlSerializer(typeof(Group));

            // To write the file, a TextWriter is required.
            TextWriter writer = new StreamWriter(filename);

            /* Create an instance of the group to serialize, and set
               its properties. */
            Group group = new Group();
            group.GroupID = 10.089f;
            group.IsActive = false;

            group.HexBytes = new byte[1] { Convert.ToByte(100) };

            Employee x = new Employee();
            Employee y = new Employee();

            x.Name = "Jack";
            y.Name = "Jill";

            group.Employees = new Employee[2] { x, y };

            Manager mgr = new Manager();
            mgr.Name = "Sara";
            mgr.Level = 4;
            group.Manager = mgr;

            /* Add a number and a string to the 
            ArrayList returned by the ExtraInfo property. */
            group.ExtraInfo = new ArrayList();
            group.ExtraInfo.Add(42);
            group.ExtraInfo.Add("Answer");

            // Serialize the object, and close the TextWriter.      
            s.Serialize(writer, group);
            writer.Close();
        }


        public static void DeserializeObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlSerializer x = new XmlSerializer(typeof(Group));
            Group g = (Group)x.Deserialize(fs);
            Console.WriteLine(g.Manager.Name);
            Console.WriteLine(g.GroupID);
            Console.WriteLine(g.HexBytes[0]);
            foreach (Employee e in g.Employees)
            {
                Console.WriteLine(e.Name);
            }
        }
        public static void Test2()
        {
            //xml->model->xml
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(@path + "test.xml");
            Console.WriteLine(xmlDoc.OuterXml);

            AdsbEntity ad = XmlSerializeUtil.Deserialize(typeof(AdsbEntity), xmlDoc.OuterXml) as AdsbEntity;
            //Console.WriteLine(ad.Head.DatagramId);
            //Console.WriteLine(ad.Head.Fi);
            Console.WriteLine(ad.Unit[0].Name);

            string xml = XmlSerializeUtil.Serializer(typeof(AdsbEntity), ad);
            Console.WriteLine(xml);

            Console.ReadKey();
        }

        public static void CertTest()
        {
            //读取证书
            X509Certificate2 pc = new X509Certificate2(@"C:\Project\Test\ConsoleApp1\ConsoleApp1\bin\Debug\pfx\QD_WanJiaJiYunWuLiu.pfx", "91370220783721663T");
            Console.WriteLine(pc.PrivateKey.ToString());
            Console.WriteLine(pc.PublicKey.ToString());
        }

        public static void SoapTest()
        {
            //Soap测试
            //构造soap请求信息
            StringBuilder soap = new StringBuilder();
            soap.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            soap.Append("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
            soap.Append("<soap:Body>");
            soap.Append("<getWeather xmlns=\"http://WebXml.com.cn/\">");
            soap.Append("<theCityCode>2210</theCityCode>");
            soap.Append("<theUserID> </theUserID>");
            soap.Append("</getWeather>");
            soap.Append("</soap:Body>");
            soap.Append("</soap:Envelope>");

            //发起请求
            Uri uri = new Uri(@"http://www.webxml.com.cn/WebServices/WeatherWS.asmx");
            //WebRequest webRequest = WebRequest.Create(uri);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.ContentType = "text/xml";
            webRequest.Method = "POST";
            webRequest.Headers["SoapAction"] = "http://WebXml.com.cn/getWeather";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0";
            //webRequest.
            //webRequest.Credentials = null;
            using (Stream requestStream = webRequest.GetRequestStream())
            {
                byte[] paramBytes = Encoding.UTF8.GetBytes(soap.ToString());
                requestStream.Write(paramBytes, 0, paramBytes.Length);
            }

            //响应
            //WebResponse webResponse = webRequest.GetResponse();
            HttpWebResponse hwRes = webRequest.GetResponse() as HttpWebResponse;
            using (StreamReader myStreamReader = new StreamReader(hwRes.GetResponseStream(), Encoding.UTF8))
            {
                Console.WriteLine(myStreamReader.ReadToEnd());
            }
        }

        #region 测试代码

        public static int getPhoneNO()
        {
            string inputString;
            inputString = Console.ReadLine();
            while (true)
            {
                //Console.WriteLine(result);

                inputString = Console.ReadLine();
            }

        }

        public static int getSum1()
        {
            int a = 0, count = 0;
            string inputString;
            inputString = Console.ReadLine();
            while (true)
            {
                try
                {
                    a = Convert.ToInt32(inputString.Split(',')[0]);
                    count = Convert.ToInt32(inputString.Split(',')[1]);
                }
                catch
                {
                    Console.WriteLine("输入格式错误!");
                }

                //int result = 0;
                //if (count <= 0)
                //{ }
                //else
                //{
                //    for (int i = 0; i < count; i++)
                //    {
                //        result = result + Convert.ToInt32(System.Math.Pow(10, i) * a) * (count - i);
                //    }
                //}
                //Console.WriteLine(result);

                int result2 = getSum_Rec(a, 0, count);
                Console.WriteLine(result2);

                inputString = Console.ReadLine();
            }

        }

        public static int getSum_Rec(int a, int index, int count)
        {
            //四编程题
            //1、递归解法
            int result = 0;
            switch (count)
            {
                case 0:
                    result = 0;
                    break;
                case 1:
                    result = Convert.ToInt32(a * Math.Pow(10, index));
                    break;
                default:
                    result = Convert.ToInt32(a * Math.Pow(10, index) * count) + getSum_Rec(a, index + 1, count - 1);
                    break;
            }

            return result;

        }
        #endregion
    }
}

