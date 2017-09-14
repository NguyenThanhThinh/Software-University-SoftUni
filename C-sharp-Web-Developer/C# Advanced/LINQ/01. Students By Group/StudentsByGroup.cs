using System;
using System.Collections.Generic;
using System.Linq;

public static class StudentsByGroup
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
                Group = int.Parse(input[2])
            });

            input = Console.ReadLine().Split();
        }

        var filteredStudents = students
            .Where(s => s.Group == 2)
            .OrderBy(n => n.FirstName);

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

    public int Group { get; set; }
}