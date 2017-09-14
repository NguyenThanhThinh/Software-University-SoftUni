using System;

public class Startup
{
    public static void Main()
    {
        var line = Console.ReadLine();
        var engine = new CommandEngine(new JobRepo(), new EmployeeRepo(), new EmployeeFactory(), new JobFactory());

        while (!line.Equals("End"))
        {
            engine.ExecuteCommand(line);

            line = Console.ReadLine();
        }
    }
}