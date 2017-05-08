using Narato.ResponseMiddleware.Models.Models;
using System;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public class ValidationException<T> : Exception
    {
        public ModelValidationDictionary<T> ValidationMessages { get; }

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
    }
}
