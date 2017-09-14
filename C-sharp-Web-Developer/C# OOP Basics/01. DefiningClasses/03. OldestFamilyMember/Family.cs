using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> people;

    public Family()
    {
        people = new List<Person>();
    }
    public List<Person> People
    {
        get { return people; }
        set { people = value; }
    }

    public void AddMember(Person member)
    {
        this.People.Add(member);
    }

    public Person GetOldestMember()
    {
        var oldestMember = people.OrderByDescending(p => p.Age).First();

        return oldestMember;
    }
}