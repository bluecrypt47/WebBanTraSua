using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebBanTraSua.Common
{
    public class Encrypt
    {
        // Dùng để mã hóa mật khẩu bằng md5
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            // Băm password
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            // Gán kết quả sau khi băm
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // Thay đổi thành 2 chữ số thập lục phân cho mỗi byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}