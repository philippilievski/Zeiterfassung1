using System;
using System.Security.Cryptography;
using System.Text;

namespace HashPwd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Compute256Hash("blub"));
        }
        public static string Compute256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
