using System;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public class UnauthorizedException : CodedException
    {
        public UnauthorizedException() : base() { }

        public UnauthorizedException(string code, string message)
            : base(code, message) { }

        public UnauthorizedException(string errorCode, string message, Exception innerException) : base(errorCode, message, innerException) { }
    }
}
