using Narato.ResponseMiddleware.Models.Models.Interfaces;

namespace Narato.ResponseMiddleware.Models.Exceptions.Interfaces
{
    public interface IValidationException<out T> // covariance, see https://msdn.microsoft.com/en-us/library/dd799517(v=vs.110).aspx
    {
        IModelValidationDictionary<T> ValidationMessages { get; }
    }
}
