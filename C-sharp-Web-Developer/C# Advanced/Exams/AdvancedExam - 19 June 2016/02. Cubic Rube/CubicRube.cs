using System;

public class CubicRube
{
    public static void Main()
    {
        int dimention = int.Parse(Console.ReadLine());
        var input = Console.ReadLine().Split();
        uint[,,] cube = new uint[dimention, dimention, dimention];
        int counter = 0;
        ulong sum = 0;

        while (input[0] != "Analyze")
        {
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            int z = int.Parse(input[2]);
            uint value = uint.Parse(input[3]);

            if (x >= 0 && x < dimention && y >= 0 && y < dimention && z >= 0 && z < dimention)
            {
                cube[x, y, z] = value;
                if (value != 0)
                {
                    counter++;
                }
                sum += value;
            }
            input = Console.ReadLine().Split();
        }

        Console.WriteLine(sum);
        Console.WriteLine((dimention * dimention * dimention) - counter);
    }
}