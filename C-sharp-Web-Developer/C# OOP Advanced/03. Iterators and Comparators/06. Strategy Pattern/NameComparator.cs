using System.Collections.Generic;
using _05.Comparing_Objects;

namespace _06.Strategy_Pattern
{
    class NameComparator : Comparer<Person>
    {
        public override int Compare(Person x, Person y)
        {
            if (x.Name.Length.CompareTo(y.Name.Length) == 0)
            {
                return char.ToLower(x.Name[0]).CompareTo(char.ToLower(y.Name[0]));
            }
            return x.Name.Length.CompareTo(y.Name.Length);
        }
    }
}