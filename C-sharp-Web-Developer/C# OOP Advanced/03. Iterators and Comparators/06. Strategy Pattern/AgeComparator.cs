using System.Collections.Generic;
using _05.Comparing_Objects;

namespace _06.Strategy_Pattern
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}