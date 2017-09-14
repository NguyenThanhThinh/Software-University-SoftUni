namespace BePositive
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BePositiveMain
    {
        public static void Main()
        {
            int countSequences = int.Parse(Console.ReadLine().Trim());
            List<int> foundedNums = new List<int>();
            StringBuilder finalResult = new StringBuilder();

            for (int i = 0; i < countSequences; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var numbers = new List<int>();

                for (int j = 0; j < input.Length; j++)
                {
                    if (!input[j].Equals(string.Empty))
                    {
                        int num = int.Parse(input[j]);
                        numbers.Add(num);
                    }
                }

                bool found = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    int currentNum = numbers[j];

                    if (currentNum >= 0)
                    {
                        foundedNums.Add(currentNum);
                        found = true;
                    }
                    else
                    {
                        if (j + 1 < numbers.Count)
                        {
                            currentNum += numbers[j + 1];
                        }

                        if (currentNum >= 0)
                        {
                            foundedNums.Add(currentNum);
                            found = true;
                        }
                        j++;
                    }
                }

                if (!found)
                {
                    finalResult.AppendLine("(empty)");
                }
                else
                {
                    finalResult.AppendLine(string.Join(" ", foundedNums));
                }
                foundedNums.Clear();
            }
            Console.WriteLine(finalResult);
        }
    }
}