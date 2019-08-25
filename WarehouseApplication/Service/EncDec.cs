using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApplication.Service
{
    sealed class EncDec
    {
        private static int key = 33;
        private static char separator = '-';
        public static string encrypt(string line)
        {
            string encryptedLine = "";
            for (int i = 0; i < line.Length; i++)
            {
                encryptedLine += line[i] ^ key;
                encryptedLine += separator;
            }
            return encryptedLine;
        }

        public static string decrypt(string line)
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
