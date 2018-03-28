using System;
using System.Runtime.Serialization;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    [Serializable]
    public abstract class CodedException : Exception, ISerializable
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

        //Deserialization constructor.
        public CodedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            //Get the values from info and assign them to the appropriate properties
            ErrorCode = (string)info.GetValue("ErrorCode", typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ErrorCode", ErrorCode);
            base.GetObjectData(info, context);
        }
    }
}
