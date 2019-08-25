using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApplication.Users;
using WarehouseApplication.Exceptions;

namespace WarehouseApplication.Service
{
    class MethodsDB
    {
        public static bool WriteUsersFromFile(string path, List<AbstractUser> userList)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        int id = reader.ReadInt32();
                        string login = reader.ReadString();
                        string password = reader.ReadString();
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
            } catch (IOException)
            {
                return false;
            } catch (ReadObjectFromFileException)
            {
                return false;
            }
            if (userList.Count == 0) return false;
            return true;
        }

        public static bool WriteUsersToFile(string path, List<AbstractUser> userList)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    for (int i = 0; i < userList.Count; i++)
                    {
                        writer.Write(userList[i].Id);
                        writer.Write(userList[i].Login);
                        writer.Write(userList[i].Password);
                        writer.Write(userList[i].Role);
                        writer.Write(userList[i].FullName);
                    }
                }
            } catch (IOException)
            {
                return false;
            }
            
            return true;
        }
    }
}
