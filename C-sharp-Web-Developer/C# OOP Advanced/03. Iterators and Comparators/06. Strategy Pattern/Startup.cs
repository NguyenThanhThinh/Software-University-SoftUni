using System;
using System.Collections.Generic;
using _05.Comparing_Objects;

namespace _06.Strategy_Pattern
{
    public class Startup
    {
        public static void Main()
        {
            var firstSortedSet = new SortedSet<Person>(new NameComparator());
            var secondSortedSet = new SortedSet<Person>(new AgeComparator());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                firstSortedSet.Add(new Person(name, age));
                secondSortedSet.Add(new Person(name, age));
            }

            ForeachSortedSet(firstSortedSet);
            ForeachSortedSet(secondSortedSet);
        }

        private static void ForeachSortedSet(SortedSet<Person> firstSortedSet)
        {
            foreach (var person in firstSortedSet)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}