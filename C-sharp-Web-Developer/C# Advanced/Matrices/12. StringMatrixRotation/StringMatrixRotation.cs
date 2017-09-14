using System;
using System.Collections.Generic;
using System.Linq;

class StringMatrixRotation
{
    static void Main()
    {
        string inputCommand = Console.ReadLine();
        string command = inputCommand;
        string inputChars = Console.ReadLine();
        List<List<char>> inputMatrix = new List<List<char>>();
        int countInputLenght = 0;

        while (inputChars != "END")
        {
            if (countInputLenght < inputChars.Length)
            {
                countInputLenght = inputChars.Length;
            }
            inputMatrix.Add(inputChars.ToCharArray().ToList());
            inputChars = Console.ReadLine();
        }

        foreach (var stringInput in inputMatrix)
        {
            for (int i = stringInput.Count; i < countInputLenght; i++)
            {
                stringInput.Add(' ');
            }
        }

        int degrees = 0;
        string getDegrees = command.Substring(7, (command.Length - 1) - 7);
        degrees = int.Parse(getDegrees);

        if (degrees != 90 || degrees != 180 || degrees != 270)
        {
            WhichRotationMethodToUse(inputMatrix, (degrees / 90) % 4);
        }
        else if (degrees == 90)
        {
            RotateNinetyDegrees(inputMatrix);
        }
        else if (degrees == 180)
        {
            RotateOneHundredAndEightyDegrees(inputMatrix);
        }
        else
        {
            RotateTwoHundredAndSeventyDegrees(inputMatrix);
        }

    }

    public static void RotateNinetyDegrees(List<List<char>> inputMatrix)
    {
        for (int col = 0; col < inputMatrix[0].Count; col++)
        {
            for (int row = inputMatrix.Count - 1; row >= 0; row--)
            {
                Console.Write(inputMatrix[row][col]);
            }
            Console.WriteLine();
        }
    }

    public static void RotateOneHundredAndEightyDegrees(List<List<char>> inputMatrix)
    {
        for (int row = inputMatrix.Count - 1; row >= 0; row--)
        {
            for (int col = inputMatrix[row].Count - 1; col >= 0; col--)
            {
                Console.Write(inputMatrix[row][col]);
            }
            Console.WriteLine();
        }
    }

    public static void RotateTwoHundredAndSeventyDegrees(List<List<char>> inputMatrix)
    {
        for (int col = inputMatrix[0].Count - 1; col >= 0; col--)
        {
            for (int row = 0; row < inputMatrix.Count; row++)
            {
                Console.Write(inputMatrix[row][col]);
            }
            Console.WriteLine();
        }
    }

    public static void WhichRotationMethodToUse(List<List<char>> inputMatrix, int degrees)
    {
        if (degrees == 0)
        {
            for (int row = 0; row < inputMatrix.Count; row++)
            {
                for (int col = 0; col < inputMatrix[row].Count; col++)
                {
                    Console.Write(inputMatrix[row][col]);
                }
                Console.WriteLine();
            }
        }
        else if (degrees == 1)
        {
            RotateNinetyDegrees(inputMatrix);
        }
        else if (degrees == 2)
        {
            RotateOneHundredAndEightyDegrees(inputMatrix);
        }
        else
        {
            RotateTwoHundredAndSeventyDegrees(inputMatrix);
        }
    }
}