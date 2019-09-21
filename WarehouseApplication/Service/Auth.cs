using System;
using System.Collections.ObjectModel;
using WarehouseApplication.Users;

namespace WarehouseApplication.Service
{
    /// <summary>
    /// Class with auth logic
    /// </summary>
    sealed class Auth
    {
        /// <summary>
        /// Checks given login and password in database
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="userList"></param>
        /// <returns>
        /// new user object if user with such login and password exists
        /// null if there is no such user
        /// </returns>
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
