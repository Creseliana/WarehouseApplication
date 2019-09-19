namespace WarehouseApplication.Users
{
    class Administrator : AbstractUser
    {
        public Administrator(int id, string login, string password, int role, string fullName)
            : base(id, login, password, role, fullName)
        {
        }
        public Administrator(Administrator user) : base(user)
        {
        }
    }
}
