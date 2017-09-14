using System.Collections.Generic;

public class WeeklyCalendar
{
    public List<WeeklyEntry> WeeklyEntry { get; }

    public WeeklyCalendar()
    {
        this.WeeklyEntry = new List<WeeklyEntry>();
    }

    public void AddEntry(string weekday, string notes)
    {
        this.WeeklyEntry.Add(new WeeklyEntry(weekday, notes));
    }

    public IEnumerable<WeeklyEntry> WeeklySchedule()
    {
        return this.WeeklyEntry;
    }
}