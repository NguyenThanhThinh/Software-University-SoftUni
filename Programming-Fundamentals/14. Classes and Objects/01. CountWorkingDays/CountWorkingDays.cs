using System;
using System.Collections.Generic;
using System.Globalization;

class CountWorkingDays
{
    static void Main()
    {
        //Console.Write("Write first date in format dd-MM-yyyy: ");
        string input = Console.ReadLine();
        DateTime firstDate = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        //Console.Write("Write second date in format dd-MM-yyyy: ");
        input = Console.ReadLine();
        DateTime secondDate = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        List<DateTime> nonWorkingDays = new List<DateTime>
            {
                new DateTime(firstDate.Year, 01, 01),
                new DateTime(firstDate.Year, 03, 03),
                new DateTime(firstDate.Year, 05, 01),
                new DateTime(firstDate.Year, 05, 06),
                new DateTime(firstDate.Year, 05, 24),
                new DateTime(firstDate.Year, 09, 06),
                new DateTime(firstDate.Year, 09, 22),
                new DateTime(firstDate.Year, 11, 01),
                new DateTime(firstDate.Year, 12, 24),
                new DateTime(firstDate.Year, 12, 25),
                new DateTime(firstDate.Year, 12, 26)
            };

        if (firstDate.Year != secondDate.Year)
        {
            for (int i = firstDate.Year + 1; i <= secondDate.Year; i++)
            {
                nonWorkingDays.Add(new DateTime(i, 01, 01));
                nonWorkingDays.Add(new DateTime(i, 03, 03));
                nonWorkingDays.Add(new DateTime(i, 05, 01));
                nonWorkingDays.Add(new DateTime(i, 05, 06));
                nonWorkingDays.Add(new DateTime(i, 05, 24));
                nonWorkingDays.Add(new DateTime(i, 09, 06));
                nonWorkingDays.Add(new DateTime(i, 09, 22));
                nonWorkingDays.Add(new DateTime(i, 11, 01));
                nonWorkingDays.Add(new DateTime(i, 12, 24));
                nonWorkingDays.Add(new DateTime(i, 12, 25));
                nonWorkingDays.Add(new DateTime(i, 12, 26));
            }
        }

        int totalDays = (secondDate - firstDate).Days;
        int countWorkingDays = 0;
        DateTime currentDay = new DateTime();

        for (double i = 0; i <= totalDays; i++)
        {
            currentDay = firstDate.AddDays(i);
            if (!(currentDay.DayOfWeek.ToString() == "Saturday" || currentDay.DayOfWeek.ToString() == "Sunday"))
            {
                if (!nonWorkingDays.Contains(currentDay))
                {
                    countWorkingDays++;
                }
            }
        }
        Console.WriteLine(countWorkingDays);
    }
}