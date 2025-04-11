using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotAllowedException : Exception
    {
        /* Custom exception to throw when a user attempts to perform an
         * action that is not allowed or for which they do not have permissions */

        public NotAllowedException() : base()
        {
        }

        public NotAllowedException(string message) : base(message)
        {
        }

        public NotAllowedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
