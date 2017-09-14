using System;

public class Students
{
    public static void Main()
    {
        var studentName = Console.ReadLine();

        while (!studentName.Equals("End"))
        {
            var student = new Student(studentName);
            studentName = Console.ReadLine();
        }

        Console.WriteLine(Student.Counter);
    }
}