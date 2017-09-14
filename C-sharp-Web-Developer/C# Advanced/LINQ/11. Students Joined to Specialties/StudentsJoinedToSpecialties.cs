using System;
using System.Collections.Generic;
using System.Linq;

public class StudentsJoinedToSpecialties
{
    public static void Main()
    {
        var studentsSpecialty = new List<StudentSpecialty>();
        var students = new List<Student>();
        var input = Console.ReadLine().Split();

        while (input[0] != "Students:")
        {
            studentsSpecialty.Add(new StudentSpecialty
            {
                SpecialityName = input[0] + " " + input[1],
                FacultyNumber = int.Parse(input[2])
            });
            input = Console.ReadLine().Split();
        }
        input = Console.ReadLine().Split();

        while (input[0] != "END")
        {
            students.Add(new Student
            {
                Name = input[1] + " " + input[2],
                FacultyNumber = int.Parse(input[0])
            });
            input = Console.ReadLine().Split();
        }

        var result = studentsSpecialty
            .Join(students,
                    x => x.FacultyNumber, //x represent "studentsSpecialty" List
                    y => y.FacultyNumber, //y represent "students" List
                    (x, y) => new //greating new anonymouse type with variables equal of what information we need to take, after the value of "x" and "y" is Equal
                    {
                        Name = y.Name,
                        SpecialtyName = x.SpecialityName,
                        FacultyNumber = x.FacultyNumber
                    }
                )
            .OrderBy(n => n.Name);

        foreach (var student in result)
        {
            Console.WriteLine(string.Format($"{student.Name} {student.FacultyNumber} {student.SpecialtyName}"));
        }
    }
}

public class StudentSpecialty
{
    public string SpecialityName { get; set; }

    public int FacultyNumber { get; set; }
}

public class Student
{
    public string Name { get; set; }

    public int FacultyNumber { get; set; }
}