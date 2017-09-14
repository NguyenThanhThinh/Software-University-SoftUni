using System;

public class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
        : base(layout, reportLevel)
    {
    }

    protected override void ProcessMessage(string formattedMessage)
    {
        Console.WriteLine(formattedMessage);
    }
}