using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Narato.ResponseMiddleware.Models.Models
{
    public class ModelValidationDictionary<T> : Dictionary<string, ICollection<T>>
    {
        public void Add(string field, T item)
        {
            if (field == null)
            {
                throw new ArgumentException(nameof(field));
            }
            if (item == null)
            {
                throw new ArgumentException(nameof(item));
            }

            if (! ContainsKey(field))
            {
                Add(field, new List<T>() { item });
                return;
            }
            if (this[field].Contains(item))
            {
                throw new Exception($"item for field {field} was already added to validationDictionary: {item.ToString()}");
            }
            this[field].Add(item);
        }
    }
}
