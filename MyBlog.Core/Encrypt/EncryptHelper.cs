using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MyBlog.Core.Encrypt
{
    public class EncryptHelper
    {
        #region Md5加密

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="value">值</param>
        public static string Md5_16(string value)
        {
            return Md5_16(value, Encoding.UTF8);
        }

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="encoding">字符编码</param>
        public static string Md5_16(string value, Encoding encoding)
        {
            return Md5(value, encoding, false);
        }

        /// <summary>
        /// Md5加密，返回32位结果
        /// </summary>
        /// <param name="value">值</param>
        public static string Md5_32(string value)
        {
            return Md5_32(value, Encoding.UTF8);
        }

        /// <summary>
        /// Md5加密，返回32位结果
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="encoding">字符编码</param>
        public static string Md5_32(string value, Encoding encoding)
        {
            return Md5(value, encoding, true);
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        private static string Md5(string value, Encoding encoding, bool _32bit)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var md5 = new MD5CryptoServiceProvider();
            StringBuilder sb = new StringBuilder();
            try
            {
                var hash = md5.ComputeHash(encoding.GetBytes(value));
                for (int i = 0; i < hash.Length; i++)
                    sb.AppendFormat("{0:x2}", hash[i]);
            }
            finally
            {
                md5.Clear();
            }
            return sb.ToString();
        }
        #endregion
    }
}
