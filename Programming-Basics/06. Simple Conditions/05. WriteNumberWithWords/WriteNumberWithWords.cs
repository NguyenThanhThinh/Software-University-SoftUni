using System;

class WriteNumberWithWords
{
    static void Main(string[] args)
    {
        String[] numbers = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "night", };
        String[] numbersWithDigits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", };

        string numerInput = Console.ReadLine();

        if (numerInput == "10")
        {
            Console.WriteLine("Too big");
        }

        else
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numerInput == numbersWithDigits[i])
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }
    }
}
