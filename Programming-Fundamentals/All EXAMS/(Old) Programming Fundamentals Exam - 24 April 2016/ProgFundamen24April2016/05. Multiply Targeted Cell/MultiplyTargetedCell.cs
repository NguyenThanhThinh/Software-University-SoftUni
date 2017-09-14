using System;
using System.Linq;
using System.Text;
using System.Numerics;

class MultiplyTargetedCell
{
    static void Main(string[] args)
    {
        var dimentions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimentions[0]);
        int cols = int.Parse(dimentions[1]);

        BigInteger[,] matrix = new BigInteger[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            var input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToList();

            for (int col = 0; col < input.Count; col++)
            {
                matrix[row, col] = input[col];
            }
        }

        var targetCell = Console.ReadLine().Split(' ');

        BigInteger targetCellNewValue = TargetCellCalculateValue(matrix, targetCell);

        matrix = CalculateValuesAroundTargetCell(matrix, targetCell);
        matrix[int.Parse(targetCell[0]), int.Parse(targetCell[1])] = targetCellNewValue;

        StringBuilder result = new StringBuilder();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                result.Append(matrix[row, col]);
                result.Append(" ");
            }
            result.Remove(result.Length - 1, 1);
            result.AppendLine();
        }
        Console.WriteLine(result.ToString());
    }

    private static BigInteger[,] CalculateValuesAroundTargetCell(BigInteger[,] matrix, string[] targetCell)
    {
        int targetRow = int.Parse(targetCell[0]);
        int targetCol = int.Parse(targetCell[1]);
        BigInteger targetCellValue = matrix[targetRow, targetCol];

        matrix[targetRow - 1, targetCol - 1] = matrix[targetRow - 1, targetCol - 1] * targetCellValue;
        matrix[targetRow - 1, targetCol] = matrix[targetRow - 1, targetCol] * targetCellValue;
        matrix[targetRow - 1, targetCol + 1] = matrix[targetRow - 1, targetCol + 1] * targetCellValue;
        matrix[targetRow, targetCol - 1] = matrix[targetRow, targetCol - 1] * targetCellValue;
        matrix[targetRow, targetCol + 1] = matrix[targetRow, targetCol + 1] * targetCellValue;
        matrix[targetRow + 1, targetCol - 1] = matrix[targetRow + 1, targetCol - 1] * targetCellValue;
        matrix[targetRow + 1, targetCol] = matrix[targetRow + 1, targetCol] * targetCellValue;
        matrix[targetRow + 1, targetCol + 1] = matrix[targetRow + 1, targetCol + 1] * targetCellValue;

        return matrix;
    }

    private static BigInteger TargetCellCalculateValue(BigInteger[,] matrix, string[] targetCell)
    {
        BigInteger targetCellNewValue = 0;
        int targetRow = int.Parse(targetCell[0]);
        int targetCol = int.Parse(targetCell[1]);
        BigInteger targetCellValue = matrix[targetRow, targetCol];

        targetCellNewValue = targetCellValue * (matrix[targetRow - 1, targetCol - 1] + matrix[targetRow - 1, targetCol] +
            matrix[targetRow - 1, targetCol + 1] + matrix[targetRow, targetCol - 1] + matrix[targetRow, targetCol + 1] +
            matrix[targetRow + 1, targetCol - 1] + matrix[targetRow + 1, targetCol] + matrix[targetRow + 1, targetCol + 1]);

        return targetCellNewValue;
    }
}