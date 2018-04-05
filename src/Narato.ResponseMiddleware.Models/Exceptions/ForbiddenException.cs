using System;
using System.Runtime.Serialization;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    [Serializable]
    public class ForbiddenException : CodedException
    {
        public ForbiddenException() : base() { }

        public ForbiddenException(string code, string message)
            : base(code, message) { }

        public ForbiddenException(string errorCode, string message, Exception innerException) : base(errorCode, message, innerException) { }

        //Deserialization constructor.
        public ForbiddenException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
