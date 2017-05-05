using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public bool MessageSet { get; set; }

        public EntityNotFoundException()
        {
            var bla = new ExceptionWithFeedback("kfodg", jiodg);
            MessageSet = false;
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
            MessageSet = true;
        }
    }
}
