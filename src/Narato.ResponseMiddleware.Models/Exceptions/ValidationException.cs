using Narato.ResponseMiddleware.Models.Exceptions.Interfaces;
using Narato.ResponseMiddleware.Models.Models;
using Narato.ResponseMiddleware.Models.Models.Interfaces;
using System;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public class ValidationException<T> : Exception, IValidationException<T>
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
    }
}
