namespace Arrays
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class ArraysMain
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            BigInteger[] array = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            string line = Console.ReadLine().Trim();
            string command = string.Empty;

            StringBuilder finalResult = new StringBuilder();

            while (!line.Equals("stop"))
            {
                //string line = Console.ReadLine().Trim();
                var splitLine = line.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = splitLine[0];
                int[] args = new int[2];

                if (command.Equals("add") ||
                    command.Equals("subtract") ||
                    command.Equals("multiply"))
                {
                    //string[] stringParams = line.Split(ArgumentsDelimiter);
                    args[0] = int.Parse(splitLine[1]);
                    args[1] = int.Parse(splitLine[2]);

                    PerformAction(array, command, args);
                }
                else
                {
                    PerformAction(array, command, args);
                }

                PrintArray(array, finalResult);
                line = Console.ReadLine().Trim();
            }
            Console.WriteLine(finalResult);
        }

        static void PerformAction(BigInteger[] arr, string action, int[] args)
        {
            int pos = args[0] - 1;
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    arr[pos] *= value;
                    break;
                case "add":
                    arr[pos] += value;
                    break;
                case "subtract":
                    arr[pos] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(arr);
                    break;
                case "rshift":
                    ArrayShiftRight(arr);
                    break;
            }
        }

        private static void ArrayShiftRight(BigInteger[] array)
        {
            var lastIndex = array[array.Length - 1];
            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = lastIndex;
        }

        private static void ArrayShiftLeft(BigInteger[] array)
        {
            var firstIndex = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = firstIndex;
        }

        private static void PrintArray(BigInteger[] array, StringBuilder finalResult)
        {
            finalResult.AppendLine(string.Join(" ", array));
        }
    }
}
