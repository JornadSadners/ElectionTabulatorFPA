using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataBaseObjects;

namespace Salty
{
    /// <summary>
    /// Untested , but the goal is to store inportant data like passwords or sensitive information in a hash. 
    /// </summary>
    public static class Salty
    {


        #region commented out functions. If inserting User and user info is added in baseobjects db these functions will be added back in, then tested.
        /// <summary>
        /// use this method for saving the generated hashes and the generated salt to the database 
        /// passwords are not saved, in the HashTableCheck method it
        /// </summary>
        /// <param name="DataReceived">Convert any incoming string to byte[] with System.Text.Encoding.UTF8.getByte(yourString)</param>
        /// <returns></returns>
        //public static byte[] SaveSaltAndHash(byte[] DataReceived) //Used to add a InsertHashTable in DBLayer
        //{
        //    try
        //    {
        //        byte[] salty = GetSalt(32); //First, the salt is generated
        //        byte[] saltyHash = GenerateSaltedHash(DataReceived, salty);  //Second, DataReceived + salty generate the hash.

        //        SampleDataTable.myTable.Rows.Add(salty, saltyHash);
        //        //The SQL database needs to store both the hash and the salt as varbinary, so it can be converted to a 
        //        //byte[].
        //        // DBLayer.InsertHashTable(salty, saltyHash); third, the generated hash would be saved on the data base 
        //        return saltyHash;
        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }
        //}

        #endregion 

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
        /// 
        /// 
        /// </summary>
        /// <param name="plainText">Convert any incoming string to byte[] with System.Text.Encoding.UTF8.getByte(yourString)</param>
        /// <param name="salt">Two options: use Salty.getSalt method to get the salt, or get salt from dataTable.</param>
        /// <returns></returns>
        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)//works, plaintext would be the user input, salt is salt
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
            //finally
            //{
            //    Application.Exit(); //Ends the program.
            //}

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        /// <summary>
        ///   /// compares stored hash to Hash generated from user info.
        /// if true, let them through
        /// if false error occurred
        /// </summary>
        /// <param name="FN">First Name</param>
        /// <param name="LN">Last Name</param>
        /// <param name="DOB">Date of Birth</param>
        /// <param name="Cntry">Country</param>
        /// <param name="rgn">Region</param>
        /// <param name="adrs">address</param>
        /// <param name="eml">email</param>
        /// <returns></returns>
        public static bool CheckHashTable(string FN, string LN, DateTime DOB, string Cntry, string rgn, string adrs, string eml)
        {
            int id = FindID(FN, LN); 

            string inputString = FN + LN + DOB + Cntry + rgn + adrs;

            byte[] DataReceived = Encoding.UTF8.GetBytes(inputString);
            byte[] GeneratedHash;
            VoterInfo hashtable;

            if (id !=  -1)
                hashtable =  ElectionDBClass.RetrieveVoterInfoObject(id); 
            else
            {
                return false;
            }

            DataTable dt = new DataTable();
            byte[] salt = hashtable.Salt;

            //generates a SaltedHash with the datareceived, this is to allow for a comparison between the hash on the database and the new generated hash. A hash generated with key 'A' should always create Hash 'A'. So if  hash 'A' != hash 'B', then then means one of two things: key 'a' != key 'b', or there is an error in logic some where. 
                    GeneratedHash = GenerateSaltedHash( DataReceived,  salt); 

                    if (CompareByteArrays(hashtable.Hash, GeneratedHash)) //CompareByteArrays compares byte[] Summary: checks if ID's match, if true; generates saltedhash with hash on table. 
                        return true;
            

            return false;
        }
      

        /// <summary>
        /// This functions returns true if byte[] Array1 == byte[] Array2.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static bool CompareByteArrays(byte[] array1, byte[] array2) //works
        {
            try
            {
            if (array1.Length != array2.Length) //checks if array lengths are different, if true; return false.
                return false;
            

            for (int i = 0; i < array1.Length; i++)
                if (array1[i] != array2[i])//checks if a byte is different, if true; return false .
                    return false;
                            
            return true;

            }
            catch (Exception )
            {

                return false;
            }
        }

       /// <summary>
       /// Used to manually save salt and hash of the user
       /// </summary>
       /// <param name="FN"> First Name</param>
       /// <param name="LN"> Last Name</param>
       /// <param name="DOB"> Date of Birth</param>
       /// <param name="Cntry"> Country</param>
       /// <param name="rgn"> region</param>
       /// <param name="adrs"> address </param>
       /// <param name="eml"> email</param>
       /// <returns></returns>
        public static byte[] ManuallySaveSaltAndHash(string FN, string LN, DateTime DOB, string Cntry, string rgn, string adrs, string eml) //works
        {
            try
            {
                int id = FindID(FN, LN);

                if(id == -1)
                {
                    return null;
                }
                else
                {
                    string userinput = FN + LN + DOB + Cntry + rgn + adrs;
                    byte[] DataReceived = Encoding.UTF8.GetBytes(userinput); 

                    byte[] salty = GetSalt(32); //First, the salt is generated
                    byte[] saltyHash = GenerateSaltedHash(DataReceived, salty);  //Second, DataReceived + salty generate the hash.
                    //The SQL database needs to store both the hash and the salt as varbinary, so it can be converted to a 
                    //byte[].
                    // DBLayer.InsertHashTable(id, salt, Hash); third, the generated hash would be saved on the data base 
                
                    return saltyHash;

                }

            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Hopefully this function will find the ID from Firstname and LastName, will return -1 if it can't find id.
        /// </summary>
        /// <param name="FN"> FirstName</param>
        /// <param name="LN"> LastName</param>
        /// <returns></returns>
        private static int FindID(string FN, string LN)
        {
            int id = -1;
            DataTable aaa = ElectionDBClass.VotersTable();
            foreach (DataRow dr in aaa.Rows)
            {
                if (dr[1].ToString() == FN && dr[2].ToString() == LN)
                {
                    id = (int)dr[Convert.ToInt32(0)];
                    break;
                }
                else
                    return -1;
            }
       

            return id;
        }
        //
       // public static bool GenerateVoterInfoTable() // generic
       //{

    
       //     DataTable dt = ElectionDBClass.VotersTable();
       //     string input;
       //     foreach (DataRow dr in dt.Rows)
       //     {
       //         Voter Vtr = ElectionDBClass.RetrieveVoterObject(Convert.ToInt32(dr[0]));
       //         input=Vtr.
       //     }

       //}
    }
}
 
