using System;
using System.Text;

class SequenceInMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        string[,] matrix = new string[n, m];
        string value = "";
        string savedValue = "";
        int timesRepeated = 1;
        int currentTimesRepeated = 1;

        //filling the matrix
        for (int row = 0; row < n; row++)
        {
            int index = 0;
            string[] input = Console.ReadLine().Split(' ');
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = input[index];
                index++;
            }
        }

        //checking diagonal down when n <= m
        if (n <= m)
        {
            int rowPlayer = 0;
            for (int row = 0; row < n - 1; row++)
            {
                rowPlayer = row;
                for (int col = 0; col < n - (row + 1); col++)
                {
                    value = matrix[rowPlayer, col];
                    if (value == matrix[rowPlayer + 1, col + 1])
                    {
                        savedValue = value;
                        currentTimesRepeated++;
                    }
                    else
                    {
                        currentTimesRepeated = 1;
                    }
                    rowPlayer++;
                }
            }
        }

        //checking diagonal down when n > m
        else
        {
            int rowPlayrer = 0;
            int manipulateCol = 0;
            int iterationsOfCol = (n - m) + 1;
            int counter = 0;
            currentTimesRepeated = 1;
            for (int row = 0; row < n - 1; row++)
            {
                rowPlayrer = row;
                counter++;
                currentTimesRepeated = 1;
                if (iterationsOfCol < counter)
                {
                    manipulateCol++;
                }
                for (int col = 0; col < m - 1 - manipulateCol; col++)
                {
                    value = matrix[row, col];
                    if (value == matrix[row + 1, col + 1])
                    {
                        savedValue = value;
                        currentTimesRepeated++;
                        if (currentTimesRepeated > timesRepeated)
                        {
                            timesRepeated = currentTimesRepeated;
                        }
                    }
                    else
                    {
                        currentTimesRepeated = 1;
                    }
                }
            }
        }

        //checking diagonal up when n + 2 > m
        int colPlayer = 1;
        if (n + 2 > m)
        {
            currentTimesRepeated = 1;
            for (int row = 0; row < m - 1; row++)
            {
                int rowPlayer = 0;
                currentTimesRepeated = 1;
                for (int col = colPlayer; col < m - 1; col++)
                {
                    value = matrix[rowPlayer, col];
                    if (value == matrix[rowPlayer + 1, col + 1])
                    {
                        savedValue = value;
                        currentTimesRepeated++;
                        if (currentTimesRepeated > timesRepeated)
                        {
                            timesRepeated = currentTimesRepeated;
                        }
                    }
                    else
                    {
                        currentTimesRepeated = 1;
                    }
                    rowPlayer++;
                }
                currentTimesRepeated = 1;
                colPlayer++;
            }
        }

        //checking diagonal up when n + 2 <= m
        else
        {
            colPlayer = 1;
            int manipulateCol = 0;
            int manipulateColIndexator = 1;
            int manipulateColKeyOpen = 0;
            int rowPlayer = 0;
            int manipulateRow = 0;
            int iterationOfRow = m - n;
            int counter = 0;
            currentTimesRepeated = 1;
            for (int row = rowPlayer; row < n - (manipulateRow - 1); row++)
            {
                if (counter >= iterationOfRow)
                {
                    manipulateRow++;
                }
                counter++;
                if (manipulateColIndexator > 2)
                {
                    manipulateColKeyOpen++;
                }
                else
                {
                    manipulateCol++;
                }
                for (int col = manipulateCol; col < (n + manipulateCol) - manipulateColKeyOpen - 1; col++, colPlayer++)
                {
                    value = matrix[rowPlayer, colPlayer];
                    if (value == matrix[rowPlayer + 1, colPlayer + 1])
                    {
                        savedValue = value;
                        currentTimesRepeated++;
                        if (currentTimesRepeated > timesRepeated)
                        {
                            timesRepeated = currentTimesRepeated;
                        }
                    }
                    else
                    {
                        currentTimesRepeated = 1;
                    }
                    rowPlayer++;
                }
                manipulateColIndexator++;
                colPlayer = 1;
                colPlayer++;
                currentTimesRepeated = 1;
                rowPlayer = 0;
            }
        }

        //checking swapped diagonal first part
        int nValueFirstOrNot = 0;
        if (n <= m)
        {
            nValueFirstOrNot = n;
        }
        else
        {
            nValueFirstOrNot = m;
        }

        int rowPlayerSecond = 1;
        currentTimesRepeated = 1;
        for (int row = 1; row < nValueFirstOrNot; row++)
        {
            rowPlayerSecond = row;
            for (int col = 0; col < row; col++)
            {
                value = matrix[rowPlayerSecond, col];
                if (value == matrix[rowPlayerSecond - 1, col + 1])
                {
                    currentTimesRepeated++;
                    if (currentTimesRepeated > timesRepeated)
                    {
                        timesRepeated = currentTimesRepeated;
                        savedValue = value;
                    }
                }
                else
                {
                    currentTimesRepeated = 1;
                }
                rowPlayerSecond--;
            }
            currentTimesRepeated = 1;
        }

        //checking swapped diagonal middle part

        int nMinusMOrNot = 0;
        if (n <= m)
        {
            nMinusMOrNot = m - n;
        }
        else
        {
            nMinusMOrNot = n - m;
        }

        for (int row = 0; row < nMinusMOrNot; row++)
        {
            currentTimesRepeated = 1;
            rowPlayerSecond = n - 1;
            for (int col = 1 + row; col < (m - (n + 1)) + row; col++)
            {
                value = matrix[rowPlayerSecond, col];
                if (value == matrix[rowPlayerSecond - 1, col + 1])
                {
                    currentTimesRepeated++;
                    if (currentTimesRepeated > timesRepeated)
                    {
                        timesRepeated = currentTimesRepeated;
                        savedValue = value;
                    }
                }
                else
                {
                    currentTimesRepeated--;
                }
                rowPlayerSecond--;
            }
        }

        //checking swapped diagonal second part
        if (n <= m)
        {
            colPlayer = (m - (n - 2)) - 1;
            int valueCountColsLeft = colPlayer;
            for (int row = 0; row < nValueFirstOrNot - 2; row++)
            {
                rowPlayerSecond = n - 1;
                currentTimesRepeated = 1;
                colPlayer = ((m - (n - 2)) - 1) + row;
                for (int col = 1; col < (m - valueCountColsLeft) - row; col++)
                {
                    value = matrix[rowPlayerSecond, colPlayer];
                    if (value == matrix[rowPlayerSecond - 1, colPlayer + 1])
                    {
                        currentTimesRepeated++;
                        if (currentTimesRepeated > timesRepeated)
                        {
                            timesRepeated = currentTimesRepeated;
                            savedValue = value;
                        }
                    }
                    else
                    {
                        currentTimesRepeated = 1;
                    }
                    rowPlayerSecond--;
                    colPlayer++;
                }
            }
        }
        else
        {
            //checking swapped diagonal second part (n > m)
            for (int row = 0; row < nValueFirstOrNot - 2; row++)
            {
                currentTimesRepeated = 1;
                rowPlayerSecond = n - 1;
                for (int col = 1; col < m - 1; col++)
                {
                    value = matrix[rowPlayerSecond, col];
                    if (value == matrix[rowPlayerSecond - 1, col + 1])
                    {
                        currentTimesRepeated++;
                        if (currentTimesRepeated > timesRepeated)
                        {
                            timesRepeated = currentTimesRepeated;
                            savedValue = value;
                        }
                    }
                    else
                    {
                        currentTimesRepeated = 1;
                    }
                    rowPlayerSecond--;
                }
            }
        }
        // checking for horizontal
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            currentTimesRepeated = 1;
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                value = matrix[row, col];
                if (value == matrix[row, col + 1])
                {
                    currentTimesRepeated++;
                    if (currentTimesRepeated > timesRepeated)
                    {
                        timesRepeated = currentTimesRepeated;
                        savedValue = value;
                    }
                }
                else
                {
                    currentTimesRepeated = 1;
                }
            }
        }
        //checking for vertical
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            currentTimesRepeated = 1;
            for (int row = 0; row <  matrix.GetLength(0) - 1; row++)
            {
                value = matrix[row, col];
                if (value == matrix[row + 1, col])
                {
                    currentTimesRepeated++;
                    if (currentTimesRepeated > timesRepeated)
                    {
                        timesRepeated = currentTimesRepeated;
                        savedValue = value;
                    }
                }
                else
                {
                    currentTimesRepeated = 1;
                }
            }
        }
        //printing output
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < timesRepeated; i++)
        {
            result.Append(savedValue);
            result.Append(", ");
        }
        string resultTrimmed = result.ToString().TrimEnd(',', ' ');
        Console.WriteLine(resultTrimmed);

    }
}