using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class MyList : IMyList
    {
        private int used;
        private List<string> collection;

        public int Used
        {
            get { return collection.Count; }
        }

        public MyList()
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
            this.Collection.Insert(0, input);
            return "0";
        }

        public string Remove(int range)
        {
            var result = new StringBuilder();

            for (int i = 0; i < range; i++)
            {
                var removedItem = this.Collection[0];
                this.Collection.RemoveAt(0);
                result.Append($"{removedItem} ");
            }
            result.Remove(result.Length - 1, 1);
            result.AppendLine();
            return result.ToString();
        }
    }
}