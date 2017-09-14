using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        WeeklyCalendar calendar = new WeeklyCalendar();

        calendar.AddEntry(Weekday.Monday.ToString(), "Internal meeting");
        calendar.AddEntry(Weekday.Tuesday.ToString(), "Create presentation");
        calendar.AddEntry(Weekday.Tuesday.ToString(), "Create lab and exercise");
        calendar.AddEntry(Weekday.Thursday.ToString(), "Enum Lecture");
        calendar.AddEntry(Weekday.Monday.ToString(), "Second internal meeting");

        var ordered = calendar.WeeklySchedule().OrderBy(n => n).ToList();

        foreach (var weeklyEntry in ordered)
        {
            Console.WriteLine(weeklyEntry);
        }
    }
}