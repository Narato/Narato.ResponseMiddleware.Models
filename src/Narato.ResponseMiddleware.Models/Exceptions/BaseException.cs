using System;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public abstract class BaseException : Exception
    {
        public string ErrorCode { get; set; }

        public BaseException() : base()
        {
        }

        public BaseException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
