namespace WarehouseApplication.Users
{
    class User : AbstractUser
    {
        public User(int id, string login, string password, int role, string fullName)
            : base(id, login, password, role, fullName)
        {
        }
    }
}
