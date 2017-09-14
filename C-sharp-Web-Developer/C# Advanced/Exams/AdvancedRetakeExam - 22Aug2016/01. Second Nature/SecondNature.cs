using System;
using System.Collections.Generic;
using System.Linq;

public class SecondNature
{
    public static void Main()
    {
        var flowers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var water = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        var secondNatureFlowers = new List<int>();

        int currentFlower = 0;
        int currentBucket = 0;
        int flowerIndex = 0;

        for (int i = water.Count - 1; i >= 0; i--)
        {
            if (currentBucket > 0)
            {
                water[i] += currentBucket; //if we have left water from previous flower, we added to the next bucket
            }
            if (flowerIndex == flowers.Count)
            {
                break;
            }

            currentBucket = water[i];
            for (int f = flowerIndex; f < flowers.Count;)
            {
                currentFlower = flowers[f];
                if (currentFlower < currentBucket)
                {
                    flowers[f] = 0;
                    currentBucket -= currentFlower;
                    flowerIndex++;
                    break;
                }
                else if (currentFlower > currentBucket)
                {
                    flowers[f] -= currentBucket;
                    currentBucket = 0;
                    break;
                }
                secondNatureFlowers.Add(currentFlower);
                flowers[f] = 0;
                currentBucket = 0;
                flowerIndex++;
                break;
            }
            if (i == 0)
            {
                water[i] -= currentFlower;
                if (water[i] < 0)
                {
                    water[i] = 0;
                }
            }
            else
            {
                water[i] = 0;
            }
        }

        if (water.Any(b => b != 0))
        {
            Console.WriteLine(string.Join(" ", water.Where(b => b > 0).Reverse()));
        }
        else
        {
            Console.WriteLine(string.Join(" ", flowers.Where(f => f > 0)));
        }

        if (secondNatureFlowers.Count > 0)
        {
            Console.WriteLine(string.Join(" ", secondNatureFlowers));
        }
        else
        {
            Console.WriteLine("None");
        }
    }
}