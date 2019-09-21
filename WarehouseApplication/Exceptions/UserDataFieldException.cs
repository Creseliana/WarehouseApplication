namespace WarehouseApplication.Exceptions
{
    class UserDataFieldException : WrongDataFieldException
    {
        public string ErrorMessageNoExist { get { return "Пользователя с таким логином не существует"; } }
        public string ErrorMessageExist { get { return "Пользователь с таким логином существует"; } }
        public bool UserExist { get; set; }
        public UserDataFieldException() : base()
        {
        }
        public UserDataFieldException(bool userExist) : base()
        {
            UserExist = userExist;
        }
        public UserDataFieldException(string message) : base(message)
        {
        }
    }
}
