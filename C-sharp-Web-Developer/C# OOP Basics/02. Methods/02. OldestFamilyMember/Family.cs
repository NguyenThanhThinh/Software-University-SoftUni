using System;
using System.Collections.Generic;
using System.Linq;

public class Family
{
    public List<Person> people;

    public Family()
    {
        this.people = new List<Person>();
    }

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public void GetOldestMember()
    {
        var oldestPerson = people.OrderByDescending(n => n.age).First();
        Console.WriteLine($"{oldestPerson.name} {oldestPerson.age}");
    }
}