using System;

public class Person
{
    private string name;
    private int age;
    private string occupation;


    public Person(string name, int age, string occupation)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Occupation
    {
        get { return occupation; }
        set { occupation = value; }
    }

    public override string ToString()
    {
        return String.Format($"{Name} - age: {Age}, occupation: {Occupation}");
    }
}
