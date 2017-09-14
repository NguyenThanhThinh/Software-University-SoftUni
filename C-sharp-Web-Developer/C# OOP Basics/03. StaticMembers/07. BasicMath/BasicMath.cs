using System;
using System.Text;

public class BasicMath
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var result = new StringBuilder();

        while (!input.Equals("End"))
        {
            var splitData = input.Split();
            string operation = splitData[0];
            double firstNum = double.Parse(splitData[1]);
            double secondNum = double.Parse(splitData[2]);
            string currentResult = string.Empty;

            switch (operation)
            {
                case "Sum":
                    currentResult = MathUtil.Sum(firstNum, secondNum);
                    break;
                case "Multiply":
                    currentResult = MathUtil.Multiply(firstNum, secondNum);
                    break;
                case "Subtract":
                    currentResult = MathUtil.Subtract(firstNum, secondNum);
                    break;
                case "Divide":
                    currentResult = MathUtil.Divide(firstNum, secondNum);
                    break;
                case "Percentage":
                    currentResult = MathUtil.Percentage(firstNum, secondNum);
                    break;
            }

            result.AppendLine(currentResult);

            input = Console.ReadLine();
        }

        Console.WriteLine(result);
    }
}