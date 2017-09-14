namespace LargestRectangle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;

    public static class LargestRectangle
    {
        private static int largestRectangleArea = int.MinValue;
        private static int[] RecatngleCoordinates = new int[4];

        public static void Main()
        {
            List<List<string>> items = new List<List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower().Equals("end")) break;
                items.Add(input.TrimStart(',').TrimEnd(',').Split(',').ToList());
            }

            int matrixHeight = items.Count;
            int matrixWidth = items[0].Count;

            string[,] matrix = new string[matrixHeight, matrixWidth];

            for (int row = 0; row < matrixHeight; row++)
            {
                for (int col = 0; col < matrixWidth; col++)
                {
                    matrix[row, col] = items[row][col];
                }
            }

            SearchForRectangles(matrixHeight, matrixWidth, matrix);

            Print(matrixHeight, matrixWidth, matrix);
        }

        static void Print(int matrixHeight, int matrixWidth, string[,] matrix)
        {
            int rowStart = RecatngleCoordinates[0];
            int rowEnd = RecatngleCoordinates[1];
            int colStart = RecatngleCoordinates[2];
            int colEnd = RecatngleCoordinates[3];

            for (int row = 0; row < matrixHeight; row++)
            {
                for (int col = 0; col < matrixWidth; col++)
                {
                    if ((row == rowStart && col >= colStart && col <= colEnd) ||
                        (row == rowEnd && col >= colStart && col <= colEnd) ||
                        (col == colStart && row >= rowStart && row <= rowEnd) ||
                        (col == colEnd && row >= rowStart && row <= rowEnd))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0,5}", SecurityElement.Escape("[" + matrix[row, col] + "]"));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0,5}", SecurityElement.Escape(matrix[row, col]));
                    }
                }

                Console.WriteLine();
            }
        }

        static void SearchForRectangles(int matrixHeight, int matrixWidth, string[,] matrix)
        {
            for (int row = 0; row < matrixHeight; row++)
            {
                for (int col = 0; col < matrixWidth; col++)
                {
                    for (int x = row; x < matrixHeight; x++)
                    {
                        for (int y = col; y < matrixWidth; y++)
                        {
                            if (ValidateRectangleRow(matrix, matrix[row, col], col, y, row) &&
                                ValidateRectangleCol(matrix, matrix[row, col], row, x, y) &&
                                ValidateRectangleRow(matrix, matrix[row, col], col, y, x) &&
                                ValidateRectangleCol(matrix, matrix[row, col], row, x, col))
                            {
                                int widthSize = (y - row) + 1;
                                int heightSize = (x - row) + 1;
                                int rectangleArea = widthSize * heightSize;

                                if (rectangleArea > largestRectangleArea)
                                {
                                    largestRectangleArea = rectangleArea;

                                    RecatngleCoordinates[0] = row;
                                    RecatngleCoordinates[1] = x;
                                    RecatngleCoordinates[2] = col;
                                    RecatngleCoordinates[3] = y;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool ValidateRectangleCol(string[,] matrix, string currentString, int start, int end, int col)
        {
            for (int i = start; i <= end; i++)
            {
                if (!matrix[i, col].Equals(currentString))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateRectangleRow(string[,] matrix, string currentString, int start, int end, int row)
        {
            for (int i = start; i <= end; i++)
            {
                if (!matrix[row, i].Equals(currentString))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
