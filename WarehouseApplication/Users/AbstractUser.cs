using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApplication.Users
{
    abstract class AbstractUser
    {
        public const int ADMIN = 1;
        public const int MANAGER = 2;
        public const int USER = 3;

        public int Id { get; set; }
        public string Login { get; set; }
        private string password;
        public string Password //encrypt decrypt
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
        public int Role { get; set; }
        public string FullName { get; set; }
    }
}
