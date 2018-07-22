using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Model
{
    public class ModelUpload
    { 
        private string loginName;

        /// <summary>
        /// 所需的登录用户名
        /// </summary>
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        private string loginPassword;
        /// <summary>
        /// 使用山东电子口岸提供的私钥证书对明文密码（登录用户名所需密码）进行加密，然后把byte[]转码成base64形式
        /// </summary>
        public string LoginPassword
        {
            get { return loginPassword; }
            set { loginPassword = value; }
        }

        private string fileFullName;
        /// <summary>
        /// 上传文件（报文文件zip压缩文件）名称
        /// </summary>
        public string FileFullName
        {
            get { return fileFullName; }
            set { fileFullName = value; }
        }

        private string fileBase64;
        /// <summary>
        /// 上传文件内容，然后转码为base64形式
        /// </summary>
        public string FileBase64
        {
            get { return fileBase64; }
            set { fileBase64 = value; }
        }

        private string fileLength;
        /// <summary>
        /// 上传文件大小（字节为单位）
        /// </summary>
        public string FileLength
        {
            get { return fileLength; }
            set { fileLength = value; }
        }
        private string fileMineType;
        /// <summary>
        /// 文件类型
        /// application/zip
        /// application/xml
        /// </summary>
        public string FileMimeType
        {
            get { return fileMineType; }
            set { fileMineType = value; }
        }

        private string textEncode;
        /// <summary>
        /// 预留字段
        /// </summary>
        public string TextEncode
        {
            get { return textEncode; }
            set { textEncode = value; }
        }

        [DefaultValue("ecommerce")]
        private string msgType ;
        /// <summary>
        /// 报文文件类型。跨境默认为：ecommerce
        /// </summary>
        public string MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }

        [DefaultValue("ecommerce")]
        private string projectEName ;
        /// <summary>
        /// 项目英文名称。跨境默认为：ecommerce
        /// </summary>
        public string ProjectEName
        {
            get { return projectEName; }
            set { projectEName = value; }
        }


        private string digestBase64;
        /// <summary>
        /// 上传文件摘要值
        /// </summary>
        public string DigestBase64
        {
            get { return digestBase64; }
            set { digestBase64 = value; }
        }

        private string signBase64;
        /// <summary>
        /// 上传文件数字证书签名
        /// </summary>
        public string SignBase64
        {
            get { return signBase64; }
            set { signBase64 = value; }
        }


    }
}
