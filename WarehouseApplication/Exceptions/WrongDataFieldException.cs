namespace WarehouseApplication.Exceptions
{
    class WrongDataFieldException : FieldException
    {
        public string ErrorMessage { get { return "Количество должно быть целочисленным значением больше нуля"; } }
        public WrongDataFieldException() : base()
        {
        }
        public WrongDataFieldException(string message) : base(message)
        {
        }
    }
}
