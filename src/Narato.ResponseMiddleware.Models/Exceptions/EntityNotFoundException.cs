using System;
using System.Runtime.Serialization;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : CodedException
    {
        public EntityNotFoundException() : base(string.Empty, string.Empty) {}

        public EntityNotFoundException(string code, string message)
            : base(code, message) {}

        public EntityNotFoundException(string errorCode, string message, Exception innerException) : base(errorCode, message, innerException) { }

        //Deserialization constructor.
        public EntityNotFoundException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
