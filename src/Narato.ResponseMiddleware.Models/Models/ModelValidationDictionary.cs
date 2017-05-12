using Narato.ResponseMiddleware.Models.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Narato.ResponseMiddleware.Models.Models
{
    public class ModelValidationDictionary<T> : Dictionary<string, ICollection<T>>, IModelValidationDictionary<T>
    {
        public new IEnumerable<IEnumerable<T>> Values
        {
            get
            {
                return base.Values;
            }
        }

        public void Add(string field, T item)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
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
