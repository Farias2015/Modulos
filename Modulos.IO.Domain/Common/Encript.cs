using System;
using System.Text;

namespace Modulos.IO.Domain.Common
{
    public static class Encript
    {
        private const string TokenSenha = "P#&t@?§~B&b";
        public static string EncriptData(string pwd)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(string.Concat(pwd, TokenSenha));
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return Convert.ToString(sb).Substring(0, 30);
        }
    }
}
