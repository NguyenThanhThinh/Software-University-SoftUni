using System;
using System.Collections.Generic;
using System.Linq;

class MatrixShuffling
{
    static void Main()
    {
        int r = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        string[,] matrix = new string[r, c];

        //creating a matrix with the given input
        for (int row = 0; row < r; row++)
        {
            for (int col = 0; col < c; col++)
            {
                matrix[row, col] = Console.ReadLine();
            }
        }

        string command = "";
        List<string> arrayOfCommands = new List<string>();
        int firstRow = 0;
        int firstCol = 0;
        int secondRow = 0;
        int secondCol = 0;

        while (command != "END")
        {
            command = Console.ReadLine();
            arrayOfCommands = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            bool continueOrNot = true;
            //checking if the input is invalid or the program should stop
            if (arrayOfCommands[0] == "END")
            {
                continueOrNot = false;
            }
            else if (arrayOfCommands[0] != "swap" || arrayOfCommands.Count != 5)
            {
                Console.WriteLine("\nInvalid input!\n");
                continueOrNot = false;
            }
            else if (int.Parse(arrayOfCommands[1]) >= r || int.Parse(arrayOfCommands[2]) >= c ||
                int.Parse(arrayOfCommands[3]) >= r || int.Parse(arrayOfCommands[4]) >= c || continueOrNot == false)
            {
                Console.WriteLine("\nInvalid input!\n");
                continueOrNot = false;
            }
            //if everything from above  is valid we do the exhange of the number in the matrix
            else if(continueOrNot)
            {
                firstRow = int.Parse(arrayOfCommands[1]);
                firstCol = int.Parse(arrayOfCommands[2]);
                secondRow = int.Parse(arrayOfCommands[3]);
                secondCol = int.Parse(arrayOfCommands[4]);

                string holdIndex = "";
                holdIndex = matrix[firstRow, firstCol];

                matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                matrix[secondRow, secondCol] = holdIndex.ToString();

                //printing the result of the matrix
                Console.WriteLine();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write("{0} ", matrix[row,col]);
                    }
                    Console.WriteLine("\n");
                }
            }
        }
    }
} 