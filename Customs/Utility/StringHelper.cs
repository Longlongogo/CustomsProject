using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp1.Utility
{
    public static class StringHelper
    {
        /// <summary>
        /// 将string加密为MD5
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string GetMD5FromString(string strSource)
        {
            string result = ""; 
            byte[] byteData = System.Text.Encoding.UTF8.GetBytes(strSource);
            MD5 md5 = MD5.Create();
            byte[] byteResult = md5.ComputeHash(byteData);
            result = System.Text.Encoding.UTF8.GetString(byteResult);
            return result;
        }

        /// <summary>
        /// 文件转Base64字符串
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public static string GetBase64FromFile(string strFilePath)
        {
            string result = "";
            if (System.IO.File.Exists(strFilePath))
            {
                using (FileStream fileStream = new FileStream(strFilePath, FileMode.Open))
                {
                    byte[] byteFile = new byte[fileStream.Length];
                    fileStream.Read(byteFile, 0, byteFile.Length);
                    result = Convert.ToBase64String(byteFile);
                }
            }
            return result;
        }

        public static bool WriteFile(string strFilePath, byte[] strSource, FileMode fileMode = FileMode.Create)
        {
            bool result = false;
            bool isFileExists = System.IO.File.Exists(strFilePath);
            //FileStream fileStream = new FileStream();
            switch (fileMode)
            {
                case FileMode.Create:
                    using (FileStream fileStream = new FileStream(strFilePath, fileMode, FileAccess.Write))
                    {
                        fileStream.Write(strSource, 0, strSource.Length);
                        fileStream.Flush();
                    }
                    break;
            }
            return result;
        }

        public static string ReadFile(string strFilePath)
        {
            string result = null;
            using (FileStream fileStream = new FileStream(strFilePath, FileMode.Open))
            {
                char[] charData = new char[fileStream.Length];
                //JsonReader reader = new JsonTextReader(strFilePath);
                byte[] byteFile = new byte[fileStream.Length];
                Decoder  decoder = Encoding.UTF8.GetDecoder();
                fileStream.Read(byteFile, 0, byteFile.Length);
                decoder.GetChars(byteFile, 0, byteFile.Length, charData, 0);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < charData.Length; i++)
                {
                    sb.Append( charData[i].ToString());
                }

                result = sb.ToString();
            }
            return result;
        }

    }
}
