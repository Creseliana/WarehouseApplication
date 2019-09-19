namespace WarehouseApplication.Users
{
    class Manager : AbstractUser
    {
        public Manager(int id, string login, string password, int role, string fullName)
            : base(id, login, password, role, fullName)
        {
        }

        public Manager(Manager user) : base(user)
        {
        }
    }
}
