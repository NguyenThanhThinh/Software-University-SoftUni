using System;
using System.Collections.Generic;
using System.Linq;

class HornetAssault
{
    public static List<long> liveHornets = new List<long>();
    static void Main()
    {
        var beehives = Console.ReadLine().Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        var hornets = Console.ReadLine().Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        long hornetsPower = GetHornetsPower(hornets);
        var liveBees = GetLiveBees(beehives, hornets, hornetsPower);

        if (liveBees.Count == 0)
        {
            Console.WriteLine(string.Join(" ", liveHornets));
        }
        else
        {
            Console.WriteLine(string.Join(" ", liveBees));
        }
    }

    private static List<long> GetLiveBees(long[] beehives, long[] hornets, long hornetsPower)
    {
        var liveBees = new List<long>();
        liveHornets = new List<long>(hornets);
        int deadHornetsCount = 0;

        for (int i = 0; i < beehives.Length; i++)
        {
            if (hornetsPower <= beehives[i])
            {
                if (beehives[i] - hornetsPower != 0)
                {
                    liveBees.Add(beehives[i] - hornetsPower);
                }
                deadHornetsCount++;
                if (liveHornets.Count > 0)
                {
                    liveHornets.RemoveAt(0);
                    hornetsPower -= hornets[deadHornetsCount - 1];
                }

            }
        }
        return liveBees;
    }

    private static long GetHornetsPower(long[] hornets)
    {
        long power = 0l;
        for (int i = 0; i < hornets.Length; i++)
        {
            power += (long)hornets[i];
        }
        return power;
    }
}