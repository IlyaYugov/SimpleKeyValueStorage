using System.Collections.Generic;

namespace Domain
{
    public interface ITestStorage
    {
        ValueModel SetValue(KeyModel key, ValueModel value);
        ValueModel GetValue(KeyModel key);
        bool RemoveValue(KeyModel key);
        IEnumerable<KeyModel> GetAllNotEmptyKeys();
    }
}