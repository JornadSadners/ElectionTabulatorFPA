using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salty
{
    /// <summary>
    /// Untested 
    /// </summary>
    public static class Salty
    {
        /// <summary>
        ///  generates salt
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
        /// <param name="plainText">Convert any incoming string to byte[] with System.Text.Encoding.UTF8.getByte(yourString)</param>
        /// <param name="salt">Two options: use Salty.getSalt method to get the salt, or get salt from dataTable.</param>
        /// <returns></returns>
        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)// plaintext would be the user input, 
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length]; //

            try
            {

                for (int i = 0; i < plainText.Length; i++)
                    plainTextWithSaltBytes[i] = plainText[i]; //generates the first half of the salted value
               

                for (int i = 0; i < salt.Length; i++) 
                    plainTextWithSaltBytes[plainText.Length + i] = salt[i]; //generates the second half of the salted value


            }
            catch (Exception ex)
            {               
                System.Windows.Forms.MessageBox.Show($"An error occurred in Salty.GenerateSaltedHash, could be a problem with generating the hash, or a problem with how the For loops are setup. \r\n \r\n The Error: \r\n {ex}");
                              
            }
            finally
            {
                Application.Exit(); //Ends the program.
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
        /// <summary>
        /// use this method for saving the generated hashes and the generated salt to the database 
        /// passwords are not saved, in the HashTableCheck method it
        /// </summary>
        /// <param name="DataReceived">Convert any incoming string to byte[] with System.Text.Encoding.UTF8.getByte(yourString)</param>
        /// <returns></returns>
        public static bool SaveSaltAndHash(byte[] DataReceived) //Used to add a InsertHashTable in DBLayer
        {
            try
            {
                byte[] salty = GetSalt(32); //First, the salt is generated
                byte[] saltyHash = GenerateSaltedHash(DataReceived, salty);  //Second, DataReceived + salty generate the hash.
                //The SQL database needs to store both the hash and the salt as varbinary, so it can be converted to a 
                //byte[].
                // DBLayer.InsertHashTable(salty, saltyHash); third, the generated hash would be saved on the data base 
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// compares stored hash to Hash generated from user info.
        /// if true, let them through
        /// </summary>
        /// <param name="DataReceived">Convert any incoming string to byte[] with System.Text.Encoding.UTF8.getByte(yourString)</param>
        /// <param name="dt">dt is the dataTable columns need to equal: ID</param>
        /// <returns></returns>
        public static bool CheckHashTable(byte[] DataReceived, DataTable dt, int id)
        {
            byte[] GeneratedHash;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].Field<int>("id") == id) //Checks if ID's match, if true; generates saltedhash, then compares generated hash with hash on dt. 
                {
                    //generates a SaltedHash with the datareceived, this is to allow for a comparison between the hash on the database and the new generated hash. A hash generated with key 'A' should always create Hash 'A'. So if  hash 'A' != hash 'B', then then means one of two things: key 'a' != key 'b', or there is an error in logic some where. 

                    GeneratedHash = GenerateSaltedHash(DataReceived, dt.Rows[i].Field<byte[]>("Salt")); 

                    if (CompareByteArrays(dt.Rows[i].Field<byte[]>("Hash"), GeneratedHash)) //CompareByteArrays compares byte[] Summary: checks if ID's match, if true; generates saltedhash with hash on table. 
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// This functions returns true if byte[] Array1 == byte[] Array2.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length) //checks if array lengths are different, if true; return false.
                return false;
            

            for (int i = 0; i < array1.Length; i++)
                if (array1[i] != array2[i])//checks if a byte is different, if true; return false .
                    return false;
                
            
            return true;
        }

    }
}
