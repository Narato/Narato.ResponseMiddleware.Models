using System;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public abstract class CodedException : Exception
    {
        public string ErrorCode { get; }

        public CodedException() : base() {}

        public CodedException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public CodedException(string errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
