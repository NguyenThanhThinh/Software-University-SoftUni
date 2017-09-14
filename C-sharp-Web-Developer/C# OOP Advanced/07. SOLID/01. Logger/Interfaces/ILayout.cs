public interface ILayout
{
    string DateTime { get; }
    string ReportLevel { get; }
    string Message { get; }
    string FormatMessage(ReportLevel level, string date, string message);
}