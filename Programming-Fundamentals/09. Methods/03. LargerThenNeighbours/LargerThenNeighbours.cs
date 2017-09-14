using System;
using System.Linq;

class LargerThenNeighbours
{
    static void Main()
    {
        Console.Write("Type numbers separeted by comma: ");
        int[] numbers = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Console.Write("\nNow check some number in given position if it's bigger then it's neighbours: ");
        int element = int.Parse(Console.ReadLine());

        CheckIfNumIsLargerThenNeighbours(numbers, element);
    }

    private static void CheckIfNumIsLargerThenNeighbours(int[] numbers, int element)
    {
        if (numbers[element] > numbers[element + 1] && numbers[element] > numbers[element - 1])
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}