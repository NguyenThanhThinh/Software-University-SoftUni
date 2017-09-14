using System;

class CharityMarathon
{
    static void Main()
    {
        int lenghtMarathon = int.Parse(Console.ReadLine());
        int numberRunners = int.Parse(Console.ReadLine());
        int avarageLaps = int.Parse(Console.ReadLine());
        int lenghtTrack = int.Parse(Console.ReadLine());
        int trackCapacity = int.Parse(Console.ReadLine());
        double moneyPerKilometer = double.Parse(Console.ReadLine());

        long maxRunners = Math.Min(numberRunners, trackCapacity * lenghtMarathon);

        long totalMeters = maxRunners * avarageLaps * lenghtTrack;
        double totalKilometers = totalMeters / 1000d;
        double moneyRaised = totalKilometers * moneyPerKilometer;

        Console.WriteLine($"Money raised: {moneyRaised:F2}");
    }
}