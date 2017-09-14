using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _08.AvarageGrades
{
    class AvarageGrades
    {
        static void Main()
        {
            var input = File.ReadAllLines(@"../../input.txt");
            var students = new List<Student>();

            for (int i = 1; i < input.Length; i++)
            {
                var currentLine = input[i].Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                students.Add(new Student());
                students[i - 1].Name = currentLine[0];
                students[i - 1].Grades.AddRange(currentLine.Where(n => n != currentLine[0]).Select(double.Parse));
            }

            foreach (var student in students.Where(n => n.AvarageGrade >= 5.00).OrderBy(m => m.Name).ThenByDescending(z => z.AvarageGrade))
            {
                File.AppendAllText(@"../../output.txt", student.Name + " -> " + student.AvarageGrade.ToString("0.00") + Environment.NewLine);
            }
        }
    }
}