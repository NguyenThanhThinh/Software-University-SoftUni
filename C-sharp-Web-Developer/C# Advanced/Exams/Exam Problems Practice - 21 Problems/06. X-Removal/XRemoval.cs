using System;
using System.Collections.Generic;
using System.Linq;

public class XRemoval
{
    public static void Main()
    {
        List<char[]> inputMatrix = new List<char[]>();
        string input = Console.ReadLine();
        List<List<char>> outputMatrix = new List<List<char>>();

        while (input != "END")
        {
            inputMatrix.Add(input.ToCharArray());
            outputMatrix.Add(input.ToCharArray().ToList());
            input = Console.ReadLine();
        }

        string firstCheck = "";
        string secondCheck = "";
        string thirdCheck = "";
        string fourthCheck = "";
        string fifthCheck = "";

        for (int row = 0; row < inputMatrix.Count - 2; row++)
        {
            int maxLenght = Math.Min(inputMatrix[row].Length - 2,
                Math.Min(inputMatrix[row + 1].Length - 1, inputMatrix[row + 2].Length - 2));
            for (int col = 0; col < maxLenght; col++)
            {
                firstCheck = inputMatrix[row][col].ToString().ToLower();
                secondCheck = inputMatrix[row][col + 2].ToString().ToLower();
                thirdCheck = inputMatrix[row + 1][col + 1].ToString().ToLower();
                fourthCheck = inputMatrix[row + 2][col].ToString().ToLower();
                fifthCheck = inputMatrix[row + 2][col + 2].ToString().ToLower();
                string symbol = fifthCheck;

                if (firstCheck == symbol && secondCheck == symbol && thirdCheck == symbol && fourthCheck == symbol && fifthCheck == symbol)
                {
                    outputMatrix[row][col] = ' ';
                    outputMatrix[row][col + 2] = ' ';
                    outputMatrix[row + 1][col + 1] = ' ';
                    outputMatrix[row + 2][col] = ' ';
                    outputMatrix[row + 2][col + 2] = ' ';
                }
            }
        }
        Console.WriteLine();

        for (int row = 0; row < outputMatrix.Count; row++)
        {
            for (int col = 0; col < outputMatrix[row].Count; col++)
            {
                if (outputMatrix[row][col] != ' ')
                {
                    Console.Write(outputMatrix[row][col]);
                }
            }
            Console.WriteLine();
        }
    }
}