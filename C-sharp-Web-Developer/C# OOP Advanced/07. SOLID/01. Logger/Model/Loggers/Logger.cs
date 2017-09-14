using System;
using System.Collections.Generic;
using System.Text;

public abstract class Logger : ILogger
{
    private List<IAppender> appenders;

    public Logger()
    {
        this.appenders = new List<IAppender>();
    }

    public List<IAppender> Appenders
    {
        get { return this.appenders; }
        set { this.appenders = value; }
    }

    public void LogMessage(string message)
    {
        foreach (var appender in this.appenders)
        {
            appender.Append(message);
        }
    }

    public void RegisterAppender(IAppender appender)
    {
        this.Appenders.Add(appender);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Logger info");
        foreach (var appender in this.appenders)
        {
            sb.AppendLine(appender.ToString());
        }
        return sb.ToString();
    }

    // TODO: I think I need to add 5 different methods here for every ReportLevel
}