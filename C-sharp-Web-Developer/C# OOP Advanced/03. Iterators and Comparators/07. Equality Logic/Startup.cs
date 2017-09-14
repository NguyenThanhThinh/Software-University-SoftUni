using System;
using System.Collections.Generic;
using _05.Comparing_Objects;

namespace _07.Equality_Logic
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var sortedSet =  new SortedSet<Person>();
            var hashSet = new HashSet<Person>();
            var test = new List<long>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                sortedSet.Add(new Person(name, age));
                hashSet.Add(new Person(name, age));
                test.Add(new Person(name, age).GetHashCode());
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}