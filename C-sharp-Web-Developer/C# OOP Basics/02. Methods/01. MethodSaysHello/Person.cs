using System;

public class Person
{
    public string name;

    public Person(string name)
    {
        this.name = name;
    }

    public string SayHello()
    {
        return String.Format($@"{name} says ""Hello""!");
    }
}