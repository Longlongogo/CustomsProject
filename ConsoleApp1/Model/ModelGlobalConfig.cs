using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp1.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1.Model
{
    public static class ModelGlobalConfig
    {
        private static readonly ModelConfig modelConfig = ModelConfig.GetInstance();

        /// <summary>
        /// 用户名
        /// </summary>
        public static string LoginName
        {
            get { return modelConfig.LoginName; }
        }

        /// <summary>
        /// 密码明文
        /// </summary>
        public static string LoginPassword_Ciphertext
        {
            get { return GetCiphertext(modelConfig.LoginPassword_Plaintext); }
        }
        public static string PfxPassword
        {
            get { return modelConfig.PfxPassword; }
        }

        private static string GetCiphertext(string PlainText)
        {
            string result = "";
            result = CertHelper.RSAEncrypt(PlainText, modelConfig.PrivateCertPath, modelConfig.PfxPassword);
            return result;
        }



    }
}
