using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class KeyValueStorage<TKey,TValue> : IKeyValueStorage<TKey, TValue>
    {
        private ConcurrentDictionary<TKey, TValue> _storage;

        public KeyValueStorage()
        {
            _storage = new ConcurrentDictionary<TKey, TValue>();
        }
        public TValue SetValue(TKey key, TValue value)
        {
             return _storage.AddOrUpdate(key, value
                 , (k, v) => value);
        }

        public TValue GetValue(TKey key)
        {
            TValue currentValue;
            _storage.TryGetValue(key, out currentValue);
            
            return currentValue;
        }

        public bool RemoveValue(TKey key)
        {
            TValue currentValue;
            if (_storage.TryGetValue(key, out currentValue))
            {
                return _storage.TryUpdate(key, default(TValue), currentValue);
            }
            
            return false;
        }

        public IEnumerable<TKey> GetAllNotEmptyKeys()
        {
            var keys = 
                _storage
                    .Where(st => st.Value != null)
                    .Select(st => st.Key);
            return keys;
        }
    }
}