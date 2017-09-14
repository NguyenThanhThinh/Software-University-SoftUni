
public class SimpleLayout : Layout
{
    public override string FormatMessage(ReportLevel level, string date, string message)
    {
        return string.Format($"{date} - {level.ToString().ToUpper()} - {message}");
    }
}