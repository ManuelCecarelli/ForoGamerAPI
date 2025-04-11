using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    //Exception thrown by Application layer. Mostly bussiness rules validations or data type format validation.
    public class AppValidationException : Exception
    {
        public AppValidationException() : base()
        {
        }

        public AppValidationException(string message) : base(message)
        {
        }

        public AppValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
