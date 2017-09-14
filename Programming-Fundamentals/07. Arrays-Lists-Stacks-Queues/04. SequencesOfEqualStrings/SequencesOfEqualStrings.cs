using System;
using System.Linq;

class SequencesOfEqualStrings
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        int count = 1;
        int position = 0;

        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                count++;
                position = i;
            }
            else
            {
                for (int p = 0; p < count; p++)
                {
                    Console.Write("{0} ", input[i]);
                }
                Console.WriteLine();
                count = 1;
            }
        }

        if (count > 1)
        {
            for (int p = 0; p < count; p++)
            {
                Console.Write("{0} ", input[position]);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine(input[input.Length - 1]);
        }
    }
}