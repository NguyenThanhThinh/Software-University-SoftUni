using System.Collections.Generic;

namespace _09.CollectionHierarchy
{
    public interface IAddableCollection
    {
        List<string> Collection { set; }
        string Add(string input);
    }
}