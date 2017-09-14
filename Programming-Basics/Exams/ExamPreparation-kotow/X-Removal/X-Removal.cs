using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Removal
{
    class Program
    {
        static void Main()
        {
            List<char[]> inputMatrix = new List<char[]>();
            var inputRow = Console.ReadLine();
            var outputMatrix = new List<char[]>();
            while (inputRow != "END")
            {
                var charArray = inputRow.ToCharArray();
                outputMatrix.Add(charArray);
                var lowerChars = inputRow.ToLower().ToCharArray();
                inputMatrix.Add(lowerChars);
                inputRow = Console.ReadLine();
            }
            for (int row = 0; row < inputMatrix.Count - 2; row++)
            {
                var maxLength = Math.Min(inputMatrix[row].Length - 1, Math.Min(inputMatrix[row+1].Length -2, inputMatrix[row+2].Length-1));
                for (int col = 0; col < maxLength; col++)
                {
                    var first = inputMatrix[row][col + 1];
                    var second = inputMatrix[row + 1][col];
                    var third = inputMatrix[row+1][col+1];
                    var fourht = inputMatrix[row + 1][col + 2];
                    var fifth = inputMatrix[row + 2][col + 1];
                    if ((first == second) && (second == third) && (third == fourht) && (fourht == fifth))
                    { 
                        outputMatrix[row][col + 1] = '\0';
                        outputMatrix[row + 1][col] = '\0';
                        outputMatrix[row+1][col+1] = '\0';
                        outputMatrix[row+1][col + 2] = '\0';
                        outputMatrix[row+2][col + 1] = '\0';
                    }

                }

            }
            foreach (var result in outputMatrix)
            {
                foreach (var ch in result)
                {
                    if(ch!='\0'){
                        Console.Write(ch);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
