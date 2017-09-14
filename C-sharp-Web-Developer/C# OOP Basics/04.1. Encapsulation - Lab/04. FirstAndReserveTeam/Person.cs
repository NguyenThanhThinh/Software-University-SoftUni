using System;

public class Person
{
    private string firstName;
    private string secondName;
    private int age;
    private double salary;

    public Person(string firstName, string secondName, int age, double salary)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.Age = age;
        this.Salary = salary;
    }

    public double Salary
    {
        get { return salary; }
        private set
        {
            if (value < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva");
            }
            salary = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or negative integer");
            }
            age = value;
        }
    }

    public string SecondName
    {
        get { return secondName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }
            secondName = value;
        }
    }

    public string FirstName
    {
        get { return firstName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }
            firstName = value;
        }
    }
}