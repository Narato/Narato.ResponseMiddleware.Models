using System;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public class ForbiddenException : CodedException
    {
        public ForbiddenException() : base() { }

        public ForbiddenException(string code, string message)
            : base(code, message) { }

        public ForbiddenException(string errorCode, string message, Exception innerException) : base(errorCode, message, innerException) { }
    }
}
