namespace WarehouseApplication.Users
{
    abstract class AbstractUser
    {
        public const int ADMIN = 1;
        public const int MANAGER = 2;
        public const int USER = 3;

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
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
