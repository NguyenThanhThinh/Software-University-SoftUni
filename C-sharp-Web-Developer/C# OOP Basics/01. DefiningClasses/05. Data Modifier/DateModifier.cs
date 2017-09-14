using System;
using System.Globalization;

public class DateModifier
{
    private double differenceBetweenTwoDates;

    public double DifferenceBetweenTwoDates
    {
        get { return differenceBetweenTwoDates; }
        set { differenceBetweenTwoDates = value; }
    }

    public void CalculateDifferenceBetweenTwoDates(string dateOne, string dateTwo)
    {
        DateTime firstDate = DateTime.ParseExact(dateOne, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(dateTwo, "yyyy MM dd", CultureInfo.InvariantCulture);

        this.DifferenceBetweenTwoDates = Math.Abs((firstDate.Date - secondDate.Date).TotalDays);
    }
}