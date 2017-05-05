using Narato.ResponseMiddleware.Models.Models;

namespace Narato.ResponseMiddleware.Models.Exceptions
{
    public class ValidationException<T> : BaseException
    {
        public ModelValidationDictionary<T> ValidationMessages { get; set; }

        public ValidationException(ModelValidationDictionary<T> validationMessages) : base()
        {
            ValidationMessages = validationMessages;
        }

        public ValidationException(string code, string message, ModelValidationDictionary<T> validationMessages) : base(code, message)
        {
            ValidationMessages = validationMessages;
        }
    }
}
