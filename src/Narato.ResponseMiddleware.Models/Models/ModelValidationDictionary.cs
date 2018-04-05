using Narato.ResponseMiddleware.Models.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Narato.ResponseMiddleware.Models.Models
{
    [Serializable]
    public class ModelValidationDictionary<T> : Dictionary<string, ICollection<T>>, IModelValidationDictionary<T>, ISerializable
    {
        //Deserialization constructor.
        public ModelValidationDictionary(SerializationInfo info, StreamingContext context) 
            : base(info, context) {  }

        public ModelValidationDictionary()
        {  }

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

        public void Add(ModelValidationDictionary<T> dict)
        {
            if (dict == null)
            {
                throw new ArgumentNullException(nameof(dict));
            }

            foreach (var kvp in dict)
            {
                foreach (var item in kvp.Value)
                {
                    Add(kvp.Key, item);
                }
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public override void OnDeserialization(object sender)
        {
            base.OnDeserialization(sender);
        }
    }
}
