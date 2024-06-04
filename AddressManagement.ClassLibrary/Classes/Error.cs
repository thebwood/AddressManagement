using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManagement.ClassLibrary.Classes
{
    public class Error
    {
        public Error() { }
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public string ErrorType { get; set; }
    }
}
