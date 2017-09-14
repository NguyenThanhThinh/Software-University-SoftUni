using System;
using System.Collections.Generic;

public class PrintPeople
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var people = new List<Person>();

        while (!input[0].Equals("END"))
        {
            people.Add(new Person(
                input[0],
                int.Parse(input[1]),
                input[2]
                ));

            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        people.Sort((a, b) => a.Age.CompareTo(b.Age));
        foreach (var person in people)
        {
            Console.WriteLine(person.ToString());
        }
    }
}