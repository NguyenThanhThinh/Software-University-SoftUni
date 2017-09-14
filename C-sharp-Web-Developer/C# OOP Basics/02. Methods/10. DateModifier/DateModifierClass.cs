using System;
using System.Globalization;

public class DateModifierClass
{
    public static string DifferenceBetweenTwoDates(string firstDate, string secondDate)
    {
        var firstDateSplit = firstDate.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var secondDateSplit = secondDate.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var modifedFirstDateInput = string.Format($"{firstDateSplit[0]}/{firstDateSplit[1]}/{firstDateSplit[2]}");
        var modifedSecondDateInput = string.Format($"{secondDateSplit[0]}/{secondDateSplit[1]}/{secondDateSplit[2]}");

        var firstDateTime = DateTime.ParseExact(modifedFirstDateInput, "yyyy/MM/dd", CultureInfo.InvariantCulture);
        var secondDateTime = DateTime.ParseExact(modifedSecondDateInput, "yyyy/MM/dd", CultureInfo.InvariantCulture);

        double difference = (firstDateTime.Date - secondDateTime.Date).Days;
        return Math.Abs(difference).ToString();
    }
}