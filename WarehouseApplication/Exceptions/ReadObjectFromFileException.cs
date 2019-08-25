using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApplication.Exceptions
{
    class ReadObjectFromFileException : Exception
    {
        public ReadObjectFromFileException(string message) : base(message) 
        {

        }
    }
}
