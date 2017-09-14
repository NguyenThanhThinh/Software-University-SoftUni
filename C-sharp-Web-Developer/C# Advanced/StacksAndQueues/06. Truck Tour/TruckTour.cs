using System;
using System.Collections.Generic;
using System.Linq;

public class TruckTour
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Queue<long> petrol = new Queue<long>();
        Queue<long> distance = new Queue<long>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().Select(long.Parse).ToArray();

            petrol.Enqueue(input[0]);
            distance.Enqueue(input[1]);
        }

        bool startOfCycle = true;
        int firstIndex = 0;

        while (startOfCycle)
        {
            long totalPetrol = 0;
            long currentDistance = 0;
            long currentPetrol = 0;

            for (int i = 0; i < n; i++)
            {
                currentPetrol = petrol.Dequeue();
                totalPetrol += currentPetrol;
                currentDistance = distance.Dequeue();
                petrol.Enqueue(currentPetrol);
                distance.Enqueue(currentDistance);
                totalPetrol -= currentDistance;

                if (totalPetrol <= 0)
                {
                    firstIndex++;
                    break;
                }
                if (i + 1 == n)
                {
                    startOfCycle = false;
                }
            }
        }
        Console.WriteLine(firstIndex);
    }
}


/*
public class TruckTour
{
    static int entries;
    static Queue<int[]> pumps;

    public static void Main(string[] args)
    {

        entries = int.Parse(Console.ReadLine());
        pumps = new Queue<int[]>();

        for (int entry = 0; entry < entries; entry++)
            pumps.Enqueue(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

        for (int entry = 0; entry < entries; entry++)
        {
            if (IsSolution())
            {
                Console.WriteLine(entry);
                break;
            }
            int[] startingPump = pumps.Dequeue();
            pumps.Enqueue(startingPump);
        }

    }

    static bool IsSolution()
    {
        int tankFuel = 0;
        bool foundAnswer = true;

        for (int entry = 0; entry < entries; entry++)
        {
            int[] currPump = pumps.Dequeue();
            tankFuel += currPump[0] - currPump[1];
            if (tankFuel < 0)
                foundAnswer = false;
            pumps.Enqueue(currPump);
        }

        if (foundAnswer)
            return true;
        else
            return false;
    }
}
*/