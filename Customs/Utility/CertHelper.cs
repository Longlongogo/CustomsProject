using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace ConsoleApp1.Utility
{
    public static class CertHelper
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strPlainText">明文</param>
        /// <param name="strPfxPath">pfx文件路径</param>
        /// <param name="strPassword">pfx文件的密码</param>
        /// <returns></returns>
        public static string RSAEncrypt(string strPlainText, string strPfxPath, string strPassword)
        {
            X509Certificate2 x509Certificate2 = new X509Certificate2();
            x509Certificate2 = new X509Certificate2(strPfxPath, strPassword);
            string xmlPublicKey = x509Certificate2.PublicKey.Key.ToXmlString(false);
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPublicKey);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(strPlainText);
            return Convert.ToBase64String(provider.Encrypt(bytes, false));
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="strCiphertext">密文</param>
        /// <param name="strPfxPath">pfx路径</param>
        /// <param name="strPassword">pfx文件的密码</param>
        /// <returns></returns>
        public static string RSADecrypt(string strCiphertext, string strPfxPath, string strPassword)
        {
            X509Certificate2 x509Certificate2 = new X509Certificate2();
            x509Certificate2 = new X509Certificate2(strPfxPath, strPassword);
            string xmlPrivateKey = x509Certificate2.PrivateKey.ToXmlString(false);

            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPrivateKey);
            byte[] rgb = Convert.FromBase64String(strCiphertext);
            byte[] bytes = provider.Decrypt(rgb, false);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }



    }
}