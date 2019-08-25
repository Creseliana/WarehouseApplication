using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApplication.Users;
using WarehouseApplication.Service;

namespace WarehouseApplication.Service
{
    sealed class Auth
    {
        public static AbstractUser CheckUser(string login, string password, List<AbstractUser> userList)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (String.Equals(EncDec.decrypt(userList[i].Login), login))
                {
                    if (String.Equals(EncDec.decrypt(userList[i].Password), password))
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
