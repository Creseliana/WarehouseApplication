using System.Collections.ObjectModel;
using System.IO;
using WarehouseApplication.Products;
using WarehouseApplication.Users;

namespace WarehouseApplication.Service
{
    /// <summary>
    /// Class for working with file. Read and write specific objects
    /// </summary>
    sealed class MethodsDB
    {
        /// <summary>
        /// Writes user objects from file in the ObservableCollection
        /// </summary>
        /// <param name="path">String, path to the file with data</param>
        /// <param name="userList">ObservableCollection, gets user objects from file</param>
        /// <returns>
        /// true - writing was successfull
        /// </returns>
        public static bool WriteUsersFromFile(string path, ObservableCollection<AbstractUser> userList)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        int id = reader.ReadInt32();
                        string login = EncDec.Decrypt(reader.ReadString());
                        string password = EncDec.Decrypt(reader.ReadString());
                        int role = reader.ReadInt32();
                        string fullName = reader.ReadString();
                        if (role == AbstractUser.ADMIN)
                        {
                            userList.Add(new Administrator(id, login, password, role, fullName));
                        }
                        if (role == AbstractUser.MANAGER)
                        {
                            userList.Add(new Manager(id, login, password, role, fullName));
                        }
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }
            if (userList.Count == 0) return false;
            return true;
        }

        /// <summary>
        /// Writes product objects from file in the ObservableCollection
        /// </summary>
        /// <param name="path">String, path to the file with data</param>
        /// <param name="productList">ObservableCollection, gets product objects from file</param>
        /// <returns>
        /// true - writing was successfull
        /// </returns>
        public static bool WriteProductsFromFile(string path, ObservableCollection<Product> productList)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        int id = reader.ReadInt32();
                        string productName = reader.ReadString();
                        int productAmount = reader.ReadInt32();
                        productList.Add(new Product(id, productName, productAmount));
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }
            if (productList.Count == 0) return false;
            return true;
        }

        /// <summary>
        /// Writes user objects from ObservableCollection to the file
        /// </summary>
        /// <param name="path">String, path to the file with data</param>
        /// <param name="userList">ObservableCollection, contains user objects</param>
        /// <returns>
        /// true - writing was successfull
        /// </returns>
        public static bool WriteUsersToFile(string path, ObservableCollection<AbstractUser> userList)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    for (int i = 0; i < userList.Count; i++)
                    {
                        writer.Write(userList[i].Id);
                        writer.Write(EncDec.Encrypt(userList[i].Login));
                        writer.Write(EncDec.Encrypt(userList[i].Password));
                        writer.Write(userList[i].Role);
                        writer.Write(userList[i].FullName);
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Writes product objects from ObservableCollection to the file
        /// </summary>
        /// <param name="path">String, path to the file with data</param>
        /// <param name="userList">ObservableCollection, contains product objects</param>
        /// <returns>
        /// true - writing was successfull
        /// </returns>
        public static bool WriteProductsToFile(string path, ObservableCollection<Product> productList)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    for (int i = 0; i < productList.Count; i++)
                    {
                        writer.Write(productList[i].Id);
                        writer.Write(productList[i].Name);
                        writer.Write(productList[i].Amount);
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }
    }
}
