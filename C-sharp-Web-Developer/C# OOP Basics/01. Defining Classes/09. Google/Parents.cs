using System;

public class Parents
{
    private string name;
    private DateTime birthDay;

    public Parents(string name, DateTime birthDay)
    {
        this.name = name;
        this.birthDay = birthDay;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public DateTime BirthDay
    {
        get { return birthDay; }
        set { birthDay = value; }
    }
}