using Narato.ResponseMiddleware.Models.Models.Interfaces;

namespace Narato.ResponseMiddleware.Models.Models
{
    public class ValidationErrorContent<T>
    {
        public IModelValidationDictionary<T> ValidationMessages { get; set; }
    }
}
