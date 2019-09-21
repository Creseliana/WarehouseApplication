using System;

namespace WarehouseApplication.Service
{
    /// <summary>
    /// Class with encrypt and decrypt logic
    /// </summary>
    sealed class EncDec
    {
        private static readonly int key = 33;
        private static readonly char separator = '-';

        /// <summary>
        /// Encrypt given string line with the key
        /// </summary>
        /// <param name="line">String, line that should be encrypted</param>
        /// <returns>String, encrypted line</returns>
        internal static string Encrypt(string line)
        {
            string encryptedLine = "";
            for (int i = 0; i < line.Length; i++)
            {
                encryptedLine += line[i] ^ key;
                encryptedLine += separator;
            }
            return encryptedLine;
        }

        /// <summary>
        /// Decrypt given string line with the key
        /// </summary>
        /// <param name="line">String, line that should be decrypted</param>
        /// <returns>String, decrypted line</returns>
        internal static string Decrypt(string line)
        {
            string decryptedLine = "";
            string[] splitLine = line.Split(separator);
            for (int i = 0; i < splitLine.Length - 1; i++)
            {
                decryptedLine += Convert.ToChar(Convert.ToInt32(splitLine[i]) ^ key);
            }
            return decryptedLine;
        }
    }
}
