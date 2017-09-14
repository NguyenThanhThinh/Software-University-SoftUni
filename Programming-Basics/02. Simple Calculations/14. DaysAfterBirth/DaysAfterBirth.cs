using System;
using System.Globalization;

class DaysAfterBirth
{
    static void Main()
    {
        string birthDate = Console.ReadLine();
        string format = "dd-MM-yyyy";
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime date = DateTime.ParseExact(birthDate, format, provider);
        date = date.AddDays(999);
        Console.WriteLine("{0}", date.ToString(format));
    }
}
