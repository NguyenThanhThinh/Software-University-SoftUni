using System;
using System.Collections.Generic;
using System.Linq;

public class GroupByGroup
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();
        List<Person> persons = new List<Person>();

        while (input[0] != "END")
        {
            persons.Add(new Person
            {
                Name = input[0] + " " + input[1],
                Group = int.Parse(input[2])
            });

            input = Console.ReadLine().Split();
        }

        var filteredPersons = persons.GroupBy(g => g.Group).ToList();

        foreach (var group in filteredPersons.OrderBy(n => n.Key))
        {
            Console.Write(string.Format($"{group.Key} - "));
            List<string> peopleInGroup = new List<string>();
            foreach (var person in group)
            {
                peopleInGroup.Add(person.Name);
            }
            Console.WriteLine(string.Join(", ", peopleInGroup));
        }
    }
}

public class Person
{
    public string Name { get; set; }

    public int Group { get; set; }
}