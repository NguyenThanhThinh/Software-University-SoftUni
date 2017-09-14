using System;

public class StringLenght
{
    public static void Main()
    {
        string input = Console.ReadLine();

        if (input.Length > 20)
        {
            Console.WriteLine(input.Substring(0, 20));
        }
        else if (input.Length < 20)
        {
            Console.WriteLine(input.PadRight(20, '*'));
        }
        else
        {
            Console.WriteLine(input);
        }
    }
}