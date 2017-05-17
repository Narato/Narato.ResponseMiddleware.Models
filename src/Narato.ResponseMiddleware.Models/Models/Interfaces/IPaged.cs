using System.Collections.Generic;

namespace Narato.ResponseMiddleware.Models.Models.Interfaces
{
    public interface IPaged<out T>
    {
        IEnumerable<T> Items { get; }
        int Skip { get; }
        int Take { get; }
        int Total { get; }
    }
}
