namespace WarehouseApplication.DB
{
    interface IUserDB
    {
        bool AddUser(string login, string password, string fullName);
        bool EditUser(string oldLogin, string newLogin, string newPassword, string newFullname);
        bool DeleteUser(string login);
        bool CheckLogin(string newLogin);
    }
}
