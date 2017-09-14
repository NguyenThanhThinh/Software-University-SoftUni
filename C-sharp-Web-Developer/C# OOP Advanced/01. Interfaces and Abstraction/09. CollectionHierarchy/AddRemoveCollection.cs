using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class AddRemoveCollection : IAddableRemovableCollection
    {
        private List<string> collection;

        public AddRemoveCollection()
        {
            this.Collection = new List<string>();
        }

        public List<string> Collection
        {
            private get { return collection; }
            set { collection = value; }
        }

        public string Add(string input)
        {
            this.Collection.Insert(0, input);
            return "0";
        }

        public string Remove(int range)
        {
            var result = new StringBuilder();

            for (int i = 0; i < range; i++)
            {
                var removedItem = this.Collection[this.Collection.Count - 1];
                this.Collection.RemoveAt(this.Collection.Count - 1);
                result.Append($"{removedItem} ");
            }
            result.Remove(result.Length - 1, 1).ToString();
            result.AppendLine();
            return result.ToString();
        }
    }
}