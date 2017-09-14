using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AverageGrade
{
    class AverageGrade
    {
        static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                students.Add(new Student());
                string[] input = Console.ReadLine().Split(' ');
                students[i].Name = input[0];
                students[i].Grades = new List<decimal>();
                for (int p = 1; p < input.Length; p++)
                {
                    students[i].Grades.Add(decimal.Parse(input[p]));
                }
            }

            var topStudents = students
                .Where(x => x.AvarageGrade >= 5.00m)
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.AvarageGrade);

            foreach (var student in topStudents)
            {
                Console.WriteLine("{0} -> {1:F2}", student.Name, student.AvarageGrade);
            }
        }
    }
}