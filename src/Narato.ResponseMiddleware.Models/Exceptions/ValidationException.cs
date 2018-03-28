using Narato.ResponseMiddleware.Models.Exceptions.Interfaces;
using Narato.ResponseMiddleware.Models.Models;
using Narato.ResponseMiddleware.Models.Models.Interfaces;
using System;
using System.Runtime.Serialization;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    [Serializable]
    public class ValidationException<T> : Exception, IValidationException<T>, ISerializable
    {
        public IModelValidationDictionary<T> ValidationMessages { get; }

        public ValidationException(ModelValidationDictionary<T> validationMessages) : base()
        {
            ValidationMessages = validationMessages;
        }

        public ValidationException(string message, ModelValidationDictionary<T> validationMessages) : base(message)
        {
            ValidationMessages = validationMessages;
        }

        public ValidationException(string message, ModelValidationDictionary<T> validationMessages, Exception innerException) : base(message, innerException)
        {
            ValidationMessages = validationMessages;
        }

        //Deserialization constructor.
        public ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        
    }
}
