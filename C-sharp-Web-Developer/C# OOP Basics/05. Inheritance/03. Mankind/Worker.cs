using System;
using System.Text;

public class Worker : Human
{
    private double weekSalary;
    private double hoursPerDay;
    private string lastName;

    public Worker(string firstName, string lastName, double weekSalary, double hoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.HoursPerDay = hoursPerDay;
        this.LastName = lastName;
    }

    public double HoursPerDay
    {
        get { return hoursPerDay; }

        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
            }
            hoursPerDay = value;
        }
    }

    public double WeekSalary
    {
        get { return weekSalary; }

        set
        {
            if (value <= 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public override string LastName
    {
        get { return lastName; }

        set
        {
            if (value.Length <= 3) // may be if the above is true and this one is true should show 2 Exceptions???
            {
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {FirstName}");
        sb.AppendLine($"Last Name: {lastName}");
        sb.AppendLine($"Week Salary: {weekSalary:0.00}");
        sb.AppendLine($"Hours per day: {hoursPerDay:0.00}");
        sb.AppendLine($"Salary per hour: {(weekSalary / 5) / hoursPerDay:0.00}");

        return sb.ToString();
    }
}