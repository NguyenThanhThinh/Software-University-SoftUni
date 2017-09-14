using System;

public class UniqueStudentNames
{
    public static void Main()
    {
        var name = Console.ReadLine();
        var studentGroup = new StudentGroup();

        while (!name.Equals("End"))
        {
            var student = new Student(name);
            studentGroup.UniqueStudents.Add(name);
            name = Console.ReadLine();
        }

        Console.WriteLine(StudentGroup.Counter);
    }
}