using System;
using System.Collections.Generic;
using System.Linq;

public static class StudentsByFirstAndLastName
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

        var filteredStudents = students
            .Where(n => n.FirstName.CompareTo(n.LastName) == -1);

        foreach (var student in filteredStudents)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }
}

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}