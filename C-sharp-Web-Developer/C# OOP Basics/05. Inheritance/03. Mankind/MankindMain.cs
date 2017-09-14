using System;

public class MankindMain
{
    public static void Main(string[] args)
    {
        try
        {
            var studentInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstNameStud = studentInput[0];
            string lastNameStud = studentInput[1];
            string facilityNum = studentInput[2];

            var student = new Student(firstNameStud, lastNameStud, facilityNum);

            var workerInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstNameWorker = workerInput[0];
            string lastNameWorker = workerInput[1];
            double weeklySalary = double.Parse(workerInput[2]);
            double workingHours = double.Parse(workerInput[3]);

            var worker = new Worker(firstNameWorker, lastNameWorker, weeklySalary, workingHours);

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException arg)
        {
            Console.WriteLine(arg.Message);
        }
    }
}
