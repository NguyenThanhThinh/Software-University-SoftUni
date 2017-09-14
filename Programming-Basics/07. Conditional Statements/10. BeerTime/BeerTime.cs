using System;
using System.Globalization;

class BeerTime
{
    static void Main(string[] args)
    {
        string time = Console.ReadLine();
        string format = "h:mm tt";
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime timeDate = DateTime.ParseExact(time, format, provider);
        double hours = double.Parse(timeDate.TimeOfDay.TotalHours.ToString());

        if ((hours < 3) || (hours >= 13))
        {
            Console.WriteLine("beer time");
        }
        else
        {
            Console.WriteLine("non-beer time");
        }
    }
}