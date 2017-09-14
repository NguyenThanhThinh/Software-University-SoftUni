using System.Collections.Generic;

namespace _09.CollectionHierarchy
{
    public class AddCollection : IAddableCollection
    {
        private List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public List<string> Collection
        {
            private get { return collection; }
            set { collection = value; }
        }

        public string Add(string input)
        {
            this.Collection.Add(input);
            return this.Collection.LastIndexOf(input).ToString();
        }
    }
}