using System;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    // This exception is used when you want to return a 5XX with an error message that does NOT get
    // hidden from the users in production (normal Exceptions their messages get hidden)
    public class ExceptionWithFeedback : CodedException
    {
        public ExceptionWithFeedback(string code, string message) : base(code, message)
        {
        }

        public ExceptionWithFeedback(string errorCode, string message, Exception innerException) : base(errorCode, message, innerException) { }
    }
}
