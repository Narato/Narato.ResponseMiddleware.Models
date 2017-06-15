using Narato.ResponseMiddleware.Models.Models.Interfaces;

namespace Narato.ResponseMiddleware.Models.Models
{
    public class ValidationErrorContent<T>
    {
        // ctor so Newtonsoft can deserialise a ValidationErrorContent. (the interfaced property otherwise causes it to fail)
        public ValidationErrorContent(ModelValidationDictionary<T> validationMessages)
        {
            ValidationMessages = validationMessages;
        }

        public IModelValidationDictionary<T> ValidationMessages { get; set; }
    }
}
