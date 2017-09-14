using System;
using System.Collections.Generic;
using System.Linq;

class AcademyGraduation
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var students = new SortedDictionary<string, List<double>>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            var name = input;
            var grades = Console.ReadLine().Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            if (!students.ContainsKey(name))
            {
                students[name] = new List<double>(grades);
            }
            else
            {
                students[name].AddRange(grades);
            }
        }

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Key} is graduated with {student.Value.Sum() / student.Value.Count}");
        }
    }
}