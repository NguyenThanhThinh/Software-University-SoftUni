using System;

class ArrayMatcher
{
    static void Main()
    {
        string inputData = Console.ReadLine();
        string[] splitedData = inputData.Split('\\');
        string firstValue = splitedData[0];
        string secondValue = splitedData[1];
        string command = splitedData[2];
        string resultJoin = "";

        if (command == "join")
        {

            for (int i = 0; i < firstValue.Length; i++)
            {
                for (int p = 0; p < secondValue.Length; p++)
                {
                    if (firstValue[i] == secondValue[p])
                    {
                        resultJoin += firstValue[i];
                    }
                }
            }
        }

        string[] orderedResultJoin = new string[resultJoin.Length];
        string test = "";

        for (int i = 0; i < resultJoin.Length - 1; i++)
        {
            int count = 0;
            int valueOfIndex = (int)resultJoin[i];
            for (int p = i + 1; p < resultJoin.Length; p++)
            {
                if (valueOfIndex <= (int)resultJoin[p])
                {
                    orderedResultJoin[count] += resultJoin[i];
                    test += resultJoin[i];
                }
            }
            count++;
            if (i < resultJoin.Length - 1)
            {
                orderedResultJoin[count] += resultJoin[resultJoin.Length - 1];
            }
        }

        for (int i = 0; i < orderedResultJoin.Length; i++)
        {
            Console.Write(orderedResultJoin[i]);
        }
        Console.WriteLine();
    }
}