namespace WarehouseApplication.Exceptions
{
    class EmptyFieldException : FieldException
    {
        public string ErrorMessage { get { return "Все поля должны быть заполнены"; } }
        public EmptyFieldException() : base()
        {
        }
        public EmptyFieldException(string message) : base(message)
        {

        }
    }
}
