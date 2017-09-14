using System;
using System.Collections.Generic;

namespace _05.Comparing_Objects
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var people = new List<Person>();

            while (!input[0].Equals("END"))
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];
                people.Add(new Person(name, age, town));

                input = Console.ReadLine().Split();
            }

            int n = int.Parse(Console.ReadLine());
            int equal = 1;
            int different = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (people[n - 1].CompareTo(people[i]) < 0)
                {
                    different++;
                }
                else if (i != n - 1)
                {
                    equal++;
                }
            }

            if (equal > 1)
            {
                Console.WriteLine($"{equal} {different} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}