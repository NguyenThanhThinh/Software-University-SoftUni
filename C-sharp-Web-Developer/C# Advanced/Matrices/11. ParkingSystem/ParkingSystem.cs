using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// за да даде 100/100 трябва да ползваме Hashset<string> или List<Hashset<int>>. При първия случай, обръщаме в string търсените координати и ги добавяме
// в като string. Във вторият случай добавяме във всеки Hashset<int> (Който в List отговаря на търсения Row) конкретния Col който търсим сега
// и правим проверка, ако го има значи мястото е заето. Не съм я пренаписал задачата, защото ми е ясна и не мисля, че ще срещна подводни камъни.
class ParkingSystem
{
    static void Main()
    {
        var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int row = dimentions[0];
        int col = dimentions[1];
        var parkingSpot = Console.ReadLine().Split();
        var result = new StringBuilder();

        List<int[]> parking = CreateParkingArea(row, col);

        while (parkingSpot[0] != "stop")
        {
            int entryRow = int.Parse(parkingSpot[0]);
            int desiredRow = int.Parse(parkingSpot[1]);
            int desiredCol = int.Parse(parkingSpot[2]);

            ParkTheCarOrLeave(entryRow, desiredRow, desiredCol, parking, result);
            parkingSpot = Console.ReadLine().Split();
        }
        Console.WriteLine(result.ToString());
    }

    private static void ParkTheCarOrLeave(int entryRow, int desiredRow, int desiredCol, List<int[]> parking, StringBuilder result)
    {
        int distance = 0;

        if (parking[desiredRow][desiredCol] == 0)
        {
            parking[desiredRow][desiredCol] = 1;
            distance = Math.Abs(entryRow - desiredRow) + desiredCol + 1;
            result.AppendLine($"{distance}");
        }
        else
        {
            if (!FindFreeParkingSpot(parking, desiredCol, desiredRow, result, entryRow))
            {
                result.AppendLine($"Row {desiredRow} full");
            }
        }
    }

    private static bool FindFreeParkingSpot(List<int[]> parking, int desiredCol, int desiredRow, StringBuilder result, int entryRow)
    {
        bool foundNewFreeParkingSpot = false;
        var freeSpotAvailable = parking[desiredRow].Contains(0);

        if (freeSpotAvailable)
        {
            for (int i = desiredCol - 1; i >= 1; i--)
            {
                if (FoundedNewParkingSlot(parking, entryRow, desiredRow, i, result, foundNewFreeParkingSpot))
                {
                    return true;
                }
            }

            for (int i = desiredCol + 1; i < parking[desiredRow].Length; i++)
            {
                if (FoundedNewParkingSlot(parking, entryRow, desiredRow, i, result, foundNewFreeParkingSpot))
                {
                    return true;
                }
            }
        }
        return foundNewFreeParkingSpot;
    }

    private static bool FoundedNewParkingSlot(List<int[]> parking, int entryRow, int desiredRow, int i, StringBuilder result, bool foundNewFreeParkingSpot)
    {
        int distance = 0;

        if (parking[desiredRow][i] == 0)
        {
            foundNewFreeParkingSpot = true;
            distance = Math.Abs(entryRow - desiredRow) + i + 1;
            parking[desiredRow][i] = 1;
            result.AppendLine($"{distance}");
            return foundNewFreeParkingSpot;
        }
        return false;
    }

    private static List<int[]> CreateParkingArea(int row, int col)
    {
        List<int[]> parking = new List<int[]>();

        for (int r = 0; r < row; r++)
        {
            parking.Add(new int[col]);
            for (int c = 0; c < col; c++)
            {
                parking[r][c] = 0;
            }
        }
        return parking;
    }
}