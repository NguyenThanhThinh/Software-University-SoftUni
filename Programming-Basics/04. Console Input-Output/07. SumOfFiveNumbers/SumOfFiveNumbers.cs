using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        string numbers = Console.ReadLine();
        double sum = 0d;
        char space = ' ';
        string[] singleNumber = numbers.Split(space);

        for (int i = 0; i < singleNumber.Length; i++)
        {
            sum += Double.Parse(singleNumber[i]);
        }

        Console.WriteLine(sum);

    }
}