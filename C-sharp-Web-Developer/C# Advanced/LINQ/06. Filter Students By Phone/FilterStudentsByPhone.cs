using System;
using System.Collections.Generic;
using System.Linq;

public class FilterStudentsByPhone
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
                LastName = input[1],
                Phone = input[2]
            });

            input = Console.ReadLine().Split();
        }

        var filteredStudents = students.Where(n => n.Phone.StartsWith("02") || n.Phone.StartsWith("+3592"));

        foreach (var student in filteredStudents)
        {
            Console.WriteLine(string.Format($"{student.FirstName} {student.LastName}"));
        }
    }
}

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }
}