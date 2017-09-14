using System;
using System.Linq;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class CollectionHierarchy
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int remove = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var item in input)
            {
                sb.Append(addCollection.Add(item) + " ");
            }
            sb.AppendLine();

            foreach (var item in input)
            {
                sb.Append(addRemoveCollection.Add(item) + " ");
            }
            sb.AppendLine();

            foreach (var item in input)
            {
                sb.Append(myList.Add(item) + " ");
            }
            sb.AppendLine();

            sb.Append(addRemoveCollection.Remove(remove));
            sb.Append(myList.Remove(remove));

            Console.WriteLine(sb);
        }
    }
}