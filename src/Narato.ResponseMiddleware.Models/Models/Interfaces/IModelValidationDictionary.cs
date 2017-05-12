using System.Collections.Generic;

namespace Narato.ResponseMiddleware.Models.Models.Interfaces
{
    public interface IModelValidationDictionary<out T>
    {
        int Count { get; }
        IEnumerable<IEnumerable<T>> Values { get; }
        bool ContainsKey(string key);
    }
}
