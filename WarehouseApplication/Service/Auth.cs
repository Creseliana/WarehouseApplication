using System;
using System.Collections.ObjectModel;
using WarehouseApplication.Users;

namespace WarehouseApplication.Service
{
    sealed class Auth
    {
        internal static AbstractUser CheckUser(string login, string password, ObservableCollection<AbstractUser> userList)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (String.Equals(userList[i].Login, login))
                {
                    if (String.Equals(userList[i].Password, password))
                    {
                        if (userList[i].Role == AbstractUser.ADMIN)
                        {
                            return new Administrator((Administrator)userList[i]);
                        }
                        else if (userList[i].Role == AbstractUser.MANAGER)
                        {
                            return new Manager((Manager)userList[i]);
                        }
                        else return null;
                    }
                }
            }
            return null;
        }
    }
}
