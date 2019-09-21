namespace WarehouseApplication.DB
{
    /// <summary>
    /// Interface for user database
    /// </summary>
    interface IUserDB
    {
        /// <summary>
        /// Adds new user to existing database
        /// </summary>
        /// <param name="login">String variable, login for new user</param>
        /// <param name="password">String variable, password for new user</param>
        /// <param name="fullName">String variable, user full name</param>
        /// <returns>
        /// true - when adding user was sucessful
        /// false - when adding user failed
        /// </returns>
        bool AddUser(string login, string password, string fullName);

        /// <summary>
        /// Edits existing user in database
        /// </summary>
        /// <param name="oldLogin">String variable, login of existing user</param>
        /// <param name="newLogin">String variable, new login for user</param>
        /// <param name="newPassword">String variable, new password for user</param>
        /// <param name="newFullname">String variable, new full name</param>
        /// <returns>
        /// true - when editing user was sucessful
        /// false - when editing user failed
        /// </returns>
        bool EditUser(string oldLogin, string newLogin, string newPassword, string newFullname);

        /// <summary>
        /// Deletes existing user from database
        /// </summary>
        /// <param name="login">String variable, login of user that should be deleted</param>
        /// <returns>
        /// true - when deleting user was sucessful
        /// false - when deleting user failed
        /// </returns>
        bool DeleteUser(string login);

        /// <summary>
        /// Checks database for user with such login
        /// </summary>
        /// <param name="newLogin">String variable, login that should be checked</param>
        /// <returns>
        /// true - when there is no user with such login in DB
        /// false - when user with such login was found
        /// </returns>
        bool CheckLogin(string newLogin);
    }
}
