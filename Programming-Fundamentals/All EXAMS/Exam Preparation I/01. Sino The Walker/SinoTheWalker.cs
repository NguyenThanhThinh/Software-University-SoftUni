using System;
using System.Globalization;
using System.Numerics;

class SinoTheWalker
{
    static void Main()
    {
        DateTime startTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
        BigInteger steps = BigInteger.Parse(Console.ReadLine());
        BigInteger secondsPerStep = BigInteger.Parse(Console.ReadLine());

        BigInteger startTimeInSecond = (BigInteger)(startTime.Hour * 60 * 60) + (BigInteger)(startTime.Minute * 60) + (BigInteger)startTime.Second;
        BigInteger totalWalkInSeconds = steps * secondsPerStep;
        BigInteger totalTime = startTimeInSecond + totalWalkInSeconds;
        
        BigInteger arrivalHour = totalTime / 60 / 60;
        totalTime -= (arrivalHour * 60 * 60);
        BigInteger arrivalMinutes = totalTime / 60;
        totalTime -= (arrivalMinutes * 60);
        BigInteger arrivalSecond = totalTime;

        if (arrivalSecond > 60)
        {
            arrivalSecond %= 60;
            arrivalMinutes++;
        }
        if (arrivalMinutes > 60)
        {
            arrivalMinutes %= 60;
            arrivalHour++;
        }
        if (arrivalHour > 24)
        {
            arrivalHour %= 24;
        }

        if (arrivalHour == 24)
        {
            arrivalHour = 0;
        }
        Console.WriteLine($"Time Arrival: {arrivalHour:00}:{arrivalMinutes:00}:{arrivalSecond:00}");
    }
}