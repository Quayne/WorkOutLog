using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Core.Helpers
{
    public static class PasswordHasher
    {
        private const int SaltSize = 64;


        public static Passphrase Hash(string password)
        {
            if (password == null) throw new ArgumentNullException("password");

            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            byte[] saltBytes = GetBytes("STATiC_SALT");//CreateRandomSalt(); //For simplicity, I used a static salt.
            string hashedPassword = ComputeHash(passwordBytes, saltBytes);

            return new Passphrase
            {
                Hash = hashedPassword,
                // Convert salt from byte[] to string
                Salt = Convert.ToBase64String(saltBytes)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool Equals(string password, string salt, string hash)
        {
            return String.CompareOrdinal(hash, Hash(password, salt)) == 0;
        }

        public static string GenerateRandomSalt(int size = SaltSize)
        {
            return Convert.ToBase64String(CreateRandomSalt(size));
        }

        private static string ComputeHash(byte[] password, byte[] salt)
        {
            var passwordAndSalt = new byte[salt.Length + password.Length];

            Buffer.BlockCopy(salt, 0, passwordAndSalt, 0, salt.Length);
            Buffer.BlockCopy(password, 0, passwordAndSalt, salt.Length, password.Length);
            byte[] computedHash;
            using (HashAlgorithm algorithm = new SHA256Managed())
            {
                computedHash = algorithm.ComputeHash(passwordAndSalt);
            }
            return Convert.ToBase64String(computedHash);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private static string Hash(string password, string salt)
        {
            return ComputeHash(Encoding.Unicode.GetBytes(password), Convert.FromBase64String(salt));
        }


        /// <summary>
        /// Generate random salt.
        /// Throw new ArgumentException("size must be greater than zero.");
        /// </summary>
        /// <param name="size"></param>
        /// <returns>saltBytes</returns>
        private static byte[] CreateRandomSalt(int size = SaltSize)
        {
            if (size <= 0)
                throw new ArgumentException("size must be greater than zero.");

            var saltBytes = new Byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return saltBytes;
        }

        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
