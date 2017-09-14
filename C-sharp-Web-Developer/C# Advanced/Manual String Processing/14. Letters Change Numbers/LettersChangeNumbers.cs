using System;

public class LettersChangeNumbers
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        double position = 0d;
        double number = 0d;
        double currentSum = 0d;
        decimal finalSum = 0M;

        for (int i = 0; i < input.Length; i++)
        {
            var line = input[i].Trim(' ');
            position = char.ToUpper(line[0]) - 64;
            number = double.Parse(line.Substring(1, line.Length - 2));

            if (char.IsLower(line[0]))
            {
                currentSum += position * number;
            }
            else
            {
                double devidedSum = number / position;
                currentSum += number / position;
            }

            position = char.ToUpper(line[line.Length - 1]) - 64;

            if (char.IsLower(line[line.Length - 1]))
            {
                currentSum += position;
            }
            else
            {
                currentSum -= position;
            }

            finalSum += (decimal)currentSum;
            currentSum = 0;
        }
        Console.WriteLine("{0:F2}", finalSum);
    }
}