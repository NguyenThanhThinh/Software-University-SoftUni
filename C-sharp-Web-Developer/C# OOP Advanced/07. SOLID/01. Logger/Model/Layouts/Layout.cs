public abstract class Layout : ILayout
{
    private string dateTime;
    private string reportLevel;
    private string message;

    public string DateTime
    {
        get { return this.dateTime; }
    }

    public string ReportLevel
    {
        get { return this.reportLevel; }
    }

    public string Message
    {
        get { return this.message; }
    }

    public abstract string FormatMessage(ReportLevel level, string date, string message);
}