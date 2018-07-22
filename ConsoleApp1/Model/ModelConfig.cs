using ConsoleApp1.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Model
{
    public class ModelConfig
    {
        private static ModelConfig uniqueInstance;
        // 定义一个标识确保线程同步
        private static readonly object locker = new object();
        private BLL.BLLConfig bllConfig;
        private ModelConfig()
        {
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static ModelConfig GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new ModelConfig();
                        SetConfig();
                    }
                }
            }
            return uniqueInstance;
        }

        private static void SetConfig()
        {
            string strAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string strConfigPath = @"Config\Config.json";
            string strConfig = StringHelper.ReadFile(strAppDirectory + strConfigPath);
            JObject jsonConfig = JObject.Parse(strConfig);
            JToken ss = jsonConfig["UploadConfig"] ;
            JToken jtoken = jsonConfig.GetValue("UploadConfig");

            uniqueInstance.LoginName = jtoken["LoginName"].ToString();
            uniqueInstance.LoginPassword_Plaintext = jtoken["LoginPassword"].ToString();
            uniqueInstance.PfxPassword = jtoken["PfxPassword"].ToString();
            uniqueInstance.privateCertPath = AppDomain.CurrentDomain.BaseDirectory + jtoken["PrivateCert"].ToString();
            uniqueInstance.publicCerPath = AppDomain.CurrentDomain.BaseDirectory + jtoken["PublicCert"].ToString();

        }

        private string filePathToPack;

        public string FilePathToPack
        {
            get { return filePathToPack; }
            set { filePathToPack = value; }
        }

        private string publicCerPath;

        public string PublicCerPath
        {
            get { return publicCerPath; }
            set { publicCerPath = value; }
        }

        private string privateCertPath;

        public string PrivateCertPath
        {
            get { return privateCertPath; }
            set { privateCertPath = value; }
        }

        private string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        private string loginPassword;

        public string LoginPassword_Plaintext
        {
            get { return loginPassword; }
            set { loginPassword = value; }
        }

        private string pfxPassword;

        public string PfxPassword
        {
            get { return pfxPassword; }
            set { pfxPassword = value; }
        }


        private Dictionary<string, string> namespaces;
        public Dictionary<string, string> Namespaces
        {
            get { return namespaces; }
            set { namespaces = value; }
        }

    }
}
