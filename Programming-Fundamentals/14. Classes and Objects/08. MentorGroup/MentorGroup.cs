using _08.MentorGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class MentorGroup
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        var students = new SortedDictionary<string, Student>();
        string name = "";

        while (input != "end of dates")
        {
            var dateAndName = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            name = dateAndName[0];
            DateTime date = new DateTime();

            if (!students.ContainsKey(name))
            {
                students[name] = new Student();
                for (int i = 1; i < dateAndName.Length; i++)
                {
                    date = DateTime.ParseExact(dateAndName[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    students[name].Dates.Add(date);
                }
            }
            else
            {
                for (int i = 1; i < dateAndName.Length; i++)
                {
                    date = DateTime.ParseExact(dateAndName[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    students[name].Dates.Add(date);
                }
            }

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (input != "end of comments")
        {
            var nameAndComment = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            name = nameAndComment[0];

            if (students.ContainsKey(name))
            {
                for (int i = 1; i < nameAndComment.Length; i++)
                {
                    string comment = nameAndComment[i];
                    students[name].Comments.Add(comment);
                }
            }

            input = Console.ReadLine();
        }

        Console.WriteLine();

        foreach (var student in students)
        {
            Console.WriteLine(student.Key);
            Console.WriteLine("Comments:");
            foreach (var comment in student.Value.Comments)
            {
                Console.WriteLine("- {0}", comment);
            }
            Console.WriteLine("Dates attended:");
            foreach (var date in student.Value.Dates.OrderBy(n => n.Date))
            {
                Console.WriteLine("-- {0:dd/MM/yyyy}", date);
            }
        }
    }
}