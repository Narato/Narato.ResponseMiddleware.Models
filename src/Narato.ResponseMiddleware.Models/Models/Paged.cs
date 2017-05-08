using System.Collections.Generic;
using System.Linq;

namespace Narato.ResponseMiddleware.Models.Models
{
    public class Paged<T>
    {
        public Paged(IEnumerable<T> source, int page, int pageSize, int totalCount)
        {
            Items = source;
            Skip = (page - 1) * pageSize;
            Take = source.Count();
            Total = totalCount;
        }

        public IEnumerable<T> Items { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int Total { get; set; }
    }
}
