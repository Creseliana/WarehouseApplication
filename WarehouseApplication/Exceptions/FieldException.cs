namespace WarehouseApplication.Exceptions
{
    class FieldException : WindowException
    {
        public FieldException() : base()
        {
        }
        public FieldException(string message) : base(message)
        {
        }
    }
}
