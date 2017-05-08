namespace Narato.ResponseMiddleware.Models.Models
{
    public class ValidationErrorContent<T>
    {
        public ModelValidationDictionary<T> ValidationMessages { get; set; }
    }
}
