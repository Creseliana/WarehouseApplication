using System;
using System.Collections.ObjectModel;
using WarehouseApplication.Service;
using WarehouseApplication.Users;

namespace WarehouseApplication.DB
{
    sealed class UserDB : IUserDB
    {
        public static ObservableCollection<AbstractUser> userDB = new ObservableCollection<AbstractUser>();
        public static readonly string pathUserDB = "userDB.bin";

        public bool AddUser(string login, string password, string fullName)
        {
            if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password)
                || String.IsNullOrWhiteSpace(fullName)) return false;
            userDB.Add(new Manager(GetNextId(), login, password, AbstractUser.MANAGER, fullName));
            MethodsDB.WriteUsersToFile(pathUserDB, userDB);
            return true;
        }

        public bool EditUser(string oldLogin, string newLogin, string newPassword, string newFullname)
        {
            for (int i = 0; i < userDB.Count; i++)
            {
                if (userDB[i].Login.Equals(oldLogin))
                {
                    Manager manager = new Manager(userDB[i].Id, newLogin, newPassword, AbstractUser.MANAGER, newFullname);
                    userDB.RemoveAt(i);
                    userDB.Insert(i, manager);
                    MethodsDB.WriteUsersToFile(pathUserDB, userDB);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteUser(string login)
        {
            for (int i = 0; i < userDB.Count; i++)
            {
                if (userDB[i].Login.Equals(login))
                {
                    userDB.RemoveAt(i);
                    MethodsDB.WriteUsersToFile(pathUserDB, userDB);
                    return true;
                }
            }
            return false;
        }

        public bool CheckLogin(string login)
        {
            for (int i = 0; i < userDB.Count; i++)
            {
                if (userDB[i].Login.Equals(login)) return false;
            }
            return true;
        }

        private int GetNextId()
        {
            int biggestId = userDB[0].Id;
            for (int i = 1; i < userDB.Count; i++)
            {
                if (biggestId < userDB[i].Id)
                {
                    biggestId = userDB[i].Id;
                }
            }
            return biggestId + 1;
        }
    }
}
