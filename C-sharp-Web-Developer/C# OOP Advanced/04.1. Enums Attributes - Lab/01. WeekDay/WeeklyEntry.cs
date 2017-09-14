using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private string weekDay;
    private string notes;

    public WeeklyEntry(string weekDay, string notes)
    {
        this.WeekDay = weekDay;
        this.Notes = notes;
    }

    public string Notes
    {
        get { return this.notes; }
        private set { this.notes = value; }
    }

    public string WeekDay
    {
        get { return this.weekDay; }
        private set { this.weekDay = value; }
    }

    public int CompareTo(WeeklyEntry other)
    {
        int result = String.Compare(this.WeekDay, other.WeekDay, StringComparison.Ordinal);

        if (result == 0)
        {
            result = String.Compare(this.Notes, other.Notes, StringComparison.Ordinal);
        }
        return result;
    }

    public override string ToString()
    {
        return String.Format($"{this.WeekDay} - {this.Notes}");
    }
}