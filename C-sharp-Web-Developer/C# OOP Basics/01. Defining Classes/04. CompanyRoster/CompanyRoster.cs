using System;
using System.Collections.Generic;
using System.Linq;

public class CompanyRoster
{
    public static void Main()
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        var employeesList = new List<Employee>();

        for (int i = 0; i < numberOfPeople; i++)
        {
            var personInfo = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var person = new Employee(personInfo[0], decimal.Parse(personInfo[1]), personInfo[2], personInfo[3]);
            var emailOrAge = string.Empty;

            if (personInfo.Length > 5)
            {
                person.age = int.Parse(personInfo[5]);
            }

            if (personInfo.Length > 4)
            {
                emailOrAge = personInfo[4];
                if (emailOrAge.Contains("@"))
                {
                    person.email = emailOrAge;
                }
                else
                {
                    person.age = int.Parse(emailOrAge);
                }
            }

            employeesList.Add(person);
        }

        var result = employeesList
            .GroupBy(e => e.department)
            .Select(e => new
            {
                Department = e.Key,
                AverageSalary = e.Average(emp => emp.salary),
                Employees = e.OrderByDescending(emp => emp.salary)
            })
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Department}");

        foreach (var employee in result.Employees)
        {
            Console.WriteLine($"{employee.name} {employee.salary:F2} {employee.email} {employee.age}");
        }
    }
}