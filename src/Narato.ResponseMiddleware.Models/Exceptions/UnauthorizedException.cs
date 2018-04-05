using System;
using System.Runtime.Serialization;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    [Serializable]
    public class UnauthorizedException : CodedException
    {
        public UnauthorizedException() : base() { }

        public UnauthorizedException(string code, string message)
            : base(code, message) { }

        public UnauthorizedException(string errorCode, string message, Exception innerException) : base(errorCode, message, innerException) { }

        //Deserialization constructor.
        public UnauthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
