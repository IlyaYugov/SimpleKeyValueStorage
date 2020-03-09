using System.Collections.Generic;
using DataAccess;
using Domain;

namespace StorageImplementation
{
    public class TestStorage : ITestStorage
    {
        private IKeyValueStorage<KeyModel, ValueModel> _storage;

        public TestStorage(IKeyValueStorage<KeyModel, ValueModel> storage)
        {
            _storage = storage;
        }

        public ValueModel SetValue(KeyModel key, ValueModel value) => _storage.SetValue( key, value);

        public ValueModel GetValue(KeyModel key) => _storage.GetValue(key);

        public bool RemoveValue(KeyModel key) => _storage.RemoveValue(key);

        public IEnumerable<KeyModel> GetAllNotEmptyKeys() => _storage.GetAllNotEmptyKeys();
    }
}