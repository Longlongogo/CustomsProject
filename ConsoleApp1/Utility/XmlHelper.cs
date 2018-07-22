using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ConsoleApp1.Utility
{
    public class XmlHelper
    {
        /// <summary>
        /// 将实例输出到xml文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="XMLFileToCreate"></param>
        /// <param name="instance"></param>
        public void Serialize<T>(string XMLFileToCreate, T instance)
        {
            if (instance == null) return;

            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StreamWriter sw = new StreamWriter(XMLFileToCreate))
            {
                xs.Serialize(sw, instance);
            }
        }
        /// <summary>
        /// 将对象序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            //序列化对象  
            xml.Serialize(Stream, obj);
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="xml">XML字符串</param>  
        /// <returns></returns>  
        public static object Deserialize(Type type, string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(type);
                return xmldes.Deserialize(sr);
            }
        }
         

        public static void Validate(string xmlFileName, string schemaFileName, string nameSpace = null, ValidationEventHandler eventHandler = null)
        {
            XmlReader reader = null;
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings
                {
                    ValidationType = ValidationType.Schema
                };
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessIdentityConstraints;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                if (nameSpace == string.Empty)
                {
                    nameSpace = null;
                }
                if (string.IsNullOrEmpty(schemaFileName))
                {
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                }
                else
                {
                    XmlSchemaSet set = new XmlSchemaSet();
                    set.Add(nameSpace, schemaFileName);
                    settings.Schemas = set;
                }
                if (eventHandler != null)
                {
                    settings.ValidationEventHandler += new ValidationEventHandler(eventHandler.Invoke);
                }
                reader = XmlReader.Create(xmlFileName, settings);

                while (reader.Read())
                {
                }
            }
            catch (XmlException exception)
            {
                throw;
                //"XML文件分析错误：" + exception.Message + Environment.NewLine 
                //"错误", exception.LineNumber, exception.LinePosition, exception.Message, DateTime.Now 
            }
            catch (InvalidOperationException exception2)
            {
                throw;
                //"XML文件操作错误：" + exception2.Message + Environment.NewLine 
                //"错误", null, null, exception2.Message, DateTime.Now 
            }
            catch (FileNotFoundException exception3)
            {
                throw;
                //"文件操作错误：" + exception3.Message + Environment.NewLine 
                //"错误", null, null, exception3.Message, DateTime.Now 
            }
            catch (Exception exception4)
            {
                throw;
                //"错误：" + exception4.Message + Environment.NewLine 
                //"错误", null, null, exception4.Message, DateTime.Now 
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

    }
}
