using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Salty
{
    public static class Salty
    {
        /// <summary>
        /// 1. generate salt

        /// </summary>
        /// <param name="maximumSaltLength"></param>
        /// <returns></returns>
        private static byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }


        /// <summary>
        /// 1. creating a hash with the salt value, and user input
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)// plaintext would be the user input, 
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            try
            {


                for (int i = 0; i < plainText.Length; i++)
                {
                    plainTextWithSaltBytes[i] = plainText[i];
                }
                for (int i = 0; i < salt.Length; i++)
                {
                    plainTextWithSaltBytes[plainText.Length + i] = salt[i];
                }

            }
            catch (Exception)
            {

                throw;
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        /// <summary>
        /// use this for 
        /// </summary>
        /// <param name="UserINFO"></param>
        /// <returns></returns>
        static bool SaveSaltAndHash(byte[] UserINFO) //need to add a InsertHashTable in DBLayer
        {
            try
            {
                byte[] salty = GetSalt(32);
                byte[] saltyHash = GenerateSaltedHash(UserINFO, salty);
                // DBLayer.InsertHashTable(salty, saltyHash);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// compares stored hash to Hash generated from user info.
        /// if true let them through
        /// false give them viruses 
        /// </summary>
        /// <param name="UserINFO"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        static bool HashTableCheck(byte[] UserINFO, DataTable dt)
        {
            byte[] GeneratedHash;
            foreach (DataRow dr in dt.Rows)
            {
                GeneratedHash = GenerateSaltedHash(UserINFO, dr.Field<byte[]>("Salt"));

                if (CompareByteArrays(dr.Field<byte[]>("Hash"), GeneratedHash))
                    return true;
            }
            return false;
        }
        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
