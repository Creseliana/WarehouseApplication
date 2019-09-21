using System;

namespace WarehouseApplication.Exceptions
{
    class WindowException : Exception
    {
        public string Error { get { return "Ошибка"; } }
        public WindowException() : base()
        {
        }

        public WindowException(string message) : base(message)
        {
        }
    }
}
