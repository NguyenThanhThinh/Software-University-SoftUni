using System;
using System.Collections.Generic;
using System.Linq;

public class SortStudents
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();
        List<Student> students = new List<Student>();

        while (input[0] != "END")
        {
            students.Add(new Student
            {
                FirstName = input[0],
                LastName = input[1]
            });

            input = Console.ReadLine().Split();
        }

        foreach (var student in students.OrderBy(n => n.LastName).ThenByDescending(n => n.FirstName))
        {
            Console.WriteLine(string.Format($"{student.FirstName} {student.LastName}"));
        }
    }
}

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}