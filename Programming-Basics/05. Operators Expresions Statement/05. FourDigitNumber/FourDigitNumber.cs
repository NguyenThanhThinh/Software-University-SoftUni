using System;

class FourDigitNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] separateNumbers = new int[4];
        int sumOfNumbers = 0;

        for (int i = 0; i < 4; i++)
        {
            separateNumbers[i] = number % 10;
            number /= 10;
            sumOfNumbers += separateNumbers[i];
        }

        Console.WriteLine(sumOfNumbers);

        Console.WriteLine("{0}{1}{2}{3}", separateNumbers[0], separateNumbers[1], separateNumbers[2], separateNumbers[3]);
        Console.WriteLine("{0}{1}{2}{3}", separateNumbers[0], separateNumbers[3], separateNumbers[2], separateNumbers[1]);
        Console.WriteLine("{0}{1}{2}{3}", separateNumbers[3], separateNumbers[1], separateNumbers[2], separateNumbers[0]);
    }
}