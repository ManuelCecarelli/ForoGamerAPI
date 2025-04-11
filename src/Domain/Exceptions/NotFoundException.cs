using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        //Custom exception to throw in cases where a resource was not found

        //variant without message
        public NotFoundException() : base()
        {
        }

        //variant with message
        public NotFoundException(string message) : base(message)
        {
        }

        //variant with message and inner exception trace
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        //variant with custom message (entity + id)
        public NotFoundException(string name, object key)
            : base($"Entity {name} ({key}) was not found.")
        {
        }
    }
}
