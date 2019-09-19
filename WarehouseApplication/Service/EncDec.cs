using System;

namespace WarehouseApplication.Service
{
    sealed class EncDec
    {
        private static readonly int key = 33;
        private static readonly char separator = '-';

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
