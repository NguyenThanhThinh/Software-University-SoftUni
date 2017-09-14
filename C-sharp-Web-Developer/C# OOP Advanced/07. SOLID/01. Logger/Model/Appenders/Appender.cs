using System;

public abstract class Appender : IAppender
{
    private ILayout layout;
    private ReportLevel reportLevel;

    protected Appender(ILayout layout, ReportLevel reportLevel)
    {
        this.Layout = layout;
        this.MessageCount = 0;
        this.ReportLevel = reportLevel;
    }

    public ILayout Layout
    {
        get { return this.layout; }
        protected set { this.layout = value; }
    }

    public int MessageCount { get; private set; }

    public ReportLevel ReportLevel
    {
        get { return this.reportLevel; }
        set { this.reportLevel = value; }
    }

    public void Append(string message)
    {
        this.ParseMessage(message);
    }

    protected void ParseMessage(string message)
    {
        string[] messageTokens = message.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

        ReportLevel level = CommontServices.ParseReportLevel(messageTokens[0]);

        if (level < this.reportLevel)
        {
            return;
        }
        this.MessageCount++;
        this.ProcessMessage(this.layout.FormatMessage(level, messageTokens[1], messageTokens[2]));
    }

    protected abstract void ProcessMessage(string formattedMessage);

    public override string ToString()
    {
        return String.Format($"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, " +
                             $"Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessageCount}");
    }
}