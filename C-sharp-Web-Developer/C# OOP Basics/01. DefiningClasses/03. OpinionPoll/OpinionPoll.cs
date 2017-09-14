using System;
using System.Collections.Generic;
using System.Linq;

public class OpinionPoll
{
    public static void Main()
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < numberOfPeople; i++)
        {
            var personInfo = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            people.Add(new Person(personInfo[0], int.Parse(personInfo[1])));
        }

        var result = people.Where(a => a.age > 30).OrderBy(a => a.name);
        Console.WriteLine();

        foreach (var person in result)
        {
            Console.WriteLine($"{person.name} - {person.age}");
        }
    }
}