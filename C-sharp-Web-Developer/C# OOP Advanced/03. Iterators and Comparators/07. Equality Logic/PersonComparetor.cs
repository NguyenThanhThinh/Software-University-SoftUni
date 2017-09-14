using System;
using System.Collections.Generic;
using _05.Comparing_Objects;

namespace _07.Equality_Logic
{
    class PersonComparetor : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (String.Compare(x.Name, y.Name, StringComparison.Ordinal) == 0)
            {
                return x.Age.CompareTo(y.Age);
            }
            return String.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}
