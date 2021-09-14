using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung1.Logic
{
    public class HashPw
    { 
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
        public static bool Validation(string username, string passwordHash)
        {
            bool isCorrect = false;
            var skiverleihcontext = new ZeiterfassungContext();
            var passwordandusername = skiverleihcontext.Employees
                .Where(s => s.Username == username)
                .Where(s => s.PasswordHash == passwordHash)
                .Count();

            if (passwordandusername == 1)
            {
                isCorrect = true;
            }
            return isCorrect;
        }
    }
}
