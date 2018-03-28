using System;
using System.Runtime.Serialization;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    // This exception is used when you want to return a 5XX with an error message that does NOT get
    // hidden from the users in production (normal Exceptions their messages get hidden)
    [Serializable]
    public class ExceptionWithFeedback : CodedException, ISerializable
    {
        public ExceptionWithFeedback(string code, string message) : base(code, message)
        {
        }

        public ExceptionWithFeedback(string errorCode, string message, Exception innerException) : base(errorCode, message, innerException) { }

        //Deserialization constructor.
        public ExceptionWithFeedback(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
