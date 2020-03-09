using System;
using System.Collections.Generic;

namespace Domain
{
    public class KeyValueDomain
    {
        private ITestStorage _storage;

        public KeyValueDomain(ITestStorage storage)
        {
            _storage = storage;
        }
        
        public ValueModel SetValue(KeyModel key, ValueModel value) => _storage.SetValue( key, value);

        public ValueModel GetValue(KeyModel key) => _storage.GetValue(key);

        public bool RemoveValue(KeyModel key) => _storage.RemoveValue(key);

        public IEnumerable<KeyModel> GetAllNotEmptyKeys() => _storage.GetAllNotEmptyKeys();
    }
}