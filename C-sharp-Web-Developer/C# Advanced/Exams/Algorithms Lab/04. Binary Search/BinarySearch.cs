using System;
using System.Linq;

public class BinarySearch
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int element = int.Parse(Console.ReadLine());

        //LinearSearch(numbers, element); //this one works
        BinarySearchMethod(numbers, element); //this one should be changed a little bit - gives 50/100
    }

    private static void BinarySearchMethod(int[] numbers, int element)
    {
        int mid = 0;
        int min = 0;
        int max = numbers.Length - 1;
        bool notFound = true;

        while (min + 1 < max)
        {
            mid = min + (((max - min) / 2));
            //if (min + 2 == max)
            //{
            //    mid--;
            //}
            if (element > numbers[mid])
            {
                min = mid;
            }
            else if (element < numbers[mid])
            {
                max = mid;
            }
            else
            {
                Console.WriteLine(mid);
                notFound = false;
                break;
            }
        }
        if (notFound)
        {
            Console.WriteLine(-1);
        }
    }

    private static void LinearSearch(int[] numbers, int element)
    {
        bool notFound = true;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == element)
            {
                Console.WriteLine(i);
                notFound = false;
                break;
            }
        }
        if (notFound)
        {
            Console.WriteLine(-1);
        }
    }
}