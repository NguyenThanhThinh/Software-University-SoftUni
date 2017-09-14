using System;
using System.Linq;

class FirstLargerThenNeighbours
{
    static void Main()
    {
        Console.Write("Type numbers separeted by comma: ");
        int[] numbers = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Console.Write("The first number bigger then it's neighbours is on index: ");
        GetSequenceOfFirstElementLargerThenNeighbours(numbers);
    }

    private static void GetSequenceOfFirstElementLargerThenNeighbours(int[] numbers)
    {
        bool trueOrNot = true;
        for (int i = 1; i < numbers.Length - 1; i++)
        {

            if (numbers[i] > numbers[i + 1] && numbers[i] > numbers[i - 1] && trueOrNot)
            {
                Console.WriteLine(i);
                trueOrNot = false;
                return;
            }
        }
        if (trueOrNot)
        {
            Console.WriteLine("-1");
        }
    }

}