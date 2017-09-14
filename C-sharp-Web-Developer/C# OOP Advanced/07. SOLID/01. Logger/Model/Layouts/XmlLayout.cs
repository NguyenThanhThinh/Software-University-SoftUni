using System;
using System.Text;

public class XmlLayout : Layout
{
    public override string FormatMessage(ReportLevel level, string date, string message)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<log>")
            .AppendLine($"  <date>{date}</date>")
            .AppendLine($"  <level>{level.ToString().ToUpper()}</level>")
            .AppendLine($"  <message>{message}</message>")
            .Append("</log>");
        return sb.ToString();
    }
}