using System;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public class EntityNotFoundException : CodedException
    {
        public EntityNotFoundException() : base(string.Empty, string.Empty) {}

        public EntityNotFoundException(string code, string message)
            : base(code, message) {}

        public EntityNotFoundException(string errorCode, string message, Exception innerException) : base(errorCode, message, innerException) { }
    }
}
