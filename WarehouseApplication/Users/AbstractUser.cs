namespace WarehouseApplication.Users
{
    /// <summary>
    /// Abstract class with user logic
    /// </summary>
    abstract class AbstractUser
    {
        public const int ADMIN = 1;
        public const int MANAGER = 2;
        public const int USER = 3;

        /// <value>Gets and sets unique user ID</value>
        public int Id { get; set; }

        /// <value>Gets and sets user login</value>
        public string Login { get; set; }

        /// <value>Gets and sets user password</value>
        public string Password { get; set; }

        /// <value>Gets and sets user role</value>
        public int Role { get; set; }

        /// <value>Gets and sets user full name</value>
        public string FullName { get; set; }

        public AbstractUser(int id, string login, string password, int role, string fullName)
        {
            this.Id = id;
            this.Login = login;
            this.Password = password;
            this.Role = role;
            this.FullName = fullName;
        }

        public AbstractUser(AbstractUser user)
        {
            this.Id = user.Id;
            this.Login = user.Login;
            this.Password = user.Password;
            this.Role = user.Role;
            this.FullName = user.FullName;
        }
    }
}
