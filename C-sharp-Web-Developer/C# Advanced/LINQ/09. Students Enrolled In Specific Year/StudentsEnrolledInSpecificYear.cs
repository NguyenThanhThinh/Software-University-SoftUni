using System;
using System.Collections.Generic;
using System.Linq;

public class StudentsEnrolledInSpecificYear
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();
        List<Student> students = new List<Student>();

        while (input[0] != "END")
        {
            students.Add(new Student
            {
                FacultyNumber = input[0],
                Marks = input.Skip(1).Select(int.Parse).ToList()
            });
            input = Console.ReadLine().Split();
        }

        var filteredStudents = students
            .Where(y => y.FacultyNumber
            .EndsWith("14") || 
                y.FacultyNumber.EndsWith("15"));

        foreach (var student in filteredStudents)
        {
            Console.WriteLine(string.Join(" ", student.Marks));
        }
    }
}

public class Student
{
    public string FacultyNumber { get; set; }

    public List<int> Marks { get; set; }
}