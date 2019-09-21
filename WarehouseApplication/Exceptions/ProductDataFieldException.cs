namespace WarehouseApplication.Exceptions
{
    class ProductDataFieldException : WrongDataFieldException
    {
        public string ErrorMessageNoExist { get { return "Продукции с таким наименованием не существует"; } }
        public string ErrorMessageExist { get { return "Продукция с таким наименованием уже существует"; } }
        public bool ProductExist { get; set; }
        public ProductDataFieldException() : base()
        {
        }
        public ProductDataFieldException(bool productExist) : base()
        {
            ProductExist = productExist;
        }

        public ProductDataFieldException(string message) : base(message)
        {
        }
    }
}
