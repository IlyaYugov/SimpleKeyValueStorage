using System.Collections.Generic;

namespace DataAccess
{
    public interface IKeyValueStorage<TKey,TValue>
    {
        TValue SetValue(TKey key, TValue value);
        TValue GetValue(TKey key);
        bool RemoveValue(TKey key);
        IEnumerable<TKey> GetAllNotEmptyKeys();
    }
}