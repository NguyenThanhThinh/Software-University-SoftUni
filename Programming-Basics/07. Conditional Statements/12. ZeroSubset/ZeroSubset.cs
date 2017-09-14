using System;

class ZeroSubset
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int[] numbers = new int[5];
        bool combinationToZero = true;

        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        if (numbers[0] == 0 && numbers[1] == 0 && numbers[2] == 0 && numbers[3] == 0 && numbers[4] == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
            return;
        }

        int allEqualZero = 0;

        for (int i = 0; i < 5; i++)
        {
            if (numbers[i] == 0)
            {
                Console.WriteLine("{0} = 0", numbers[i]);
                combinationToZero = false;
            }
            allEqualZero += numbers[i];
        }

        if (allEqualZero == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
            combinationToZero = false;
        }

        for (int i = 0; i < 4; i++)
        {
            for (int p = i + 1; p < 5; p++)
            {
                if (numbers[i] + numbers[p] == 0)
                {
                    Console.WriteLine("{0} + {1} == 0", numbers[i], numbers[p]);
                    combinationToZero = false;
                }
                for (int d = p + 1; d < 5; d++)
                {
                    if (numbers[i] + numbers[p] + numbers[d] == 0)
                    {
                        Console.WriteLine("{0} + {1} + {2} = 0", numbers[i], numbers[p], numbers[d]);
                        combinationToZero = false;
                    }
                    for (int f = d + 1; f < 5; f++)
                    {
                        if (numbers[i] + numbers[p] + numbers[d] + numbers[f]== 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} + {3}= 0", numbers[i], numbers[p], numbers[d], numbers[f]);
                            combinationToZero = false;
                        }
                    }
                }
            }
        }

        if (combinationToZero)
        {
            Console.WriteLine("no zero subset");
        }
    }
}