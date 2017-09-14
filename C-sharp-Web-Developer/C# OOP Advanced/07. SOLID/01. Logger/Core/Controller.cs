using System;

public class Controller
{
    private ILogger logger;

    public Controller(ILogger logger)
    {
        this.logger = logger;
    }

    public void StartReadingMessages()
    {
        string input = Console.ReadLine();

        while (!input.Equals("END"))
        {

            logger.LogMessage(input);
            input = Console.ReadLine();
        }
        ReportInfo();
    }

    public void ReportInfo()
    {
        Console.WriteLine(this.logger);
    }
}