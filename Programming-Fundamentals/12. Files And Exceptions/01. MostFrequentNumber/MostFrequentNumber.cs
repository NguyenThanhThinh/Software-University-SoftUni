using System;
using System.Collections.Generic;
using System.IO;

class MostFrequentNumber
{
    static void Main()
    {
        var input = File.ReadAllLines("input.txt");
        int count = 1;
        int countBackUp = 1;
        List<int> biggerNumbers = new List<int>();
        int numberToSave = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var splitedInput = input[i].Split(' ');
            for (int p = 0; p < splitedInput.Length; p++)
            {
                for (int b = p + 1; b < splitedInput.Length; b++)
                {
                    if (splitedInput[p] == splitedInput[b])
                    {
                        count++;
                    }
                }
                if (count >= countBackUp)
                {
                    numberToSave = int.Parse(splitedInput[p]);

                    countBackUp = count;
                    biggerNumbers.Add(numberToSave);
                }
                count = 1;
            }

            if (biggerNumbers.Count == 1)
            {
                foreach (var number in biggerNumbers)
                {
                    string text = "The number " + number + " is the most frequent (occurs " + countBackUp + " times)";
                    File.AppendAllText("output.txt", text);
                    File.AppendAllText("output.txt", Environment.NewLine);
                }
                biggerNumbers.Clear();
                countBackUp = 1;
            }
            else
            {
                int leftNumber = biggerNumbers[0];
                biggerNumbers.Sort();
                string text = "The numbers ";
                var addText = string.Join(", ", biggerNumbers);
                addText = addText.Substring(0, addText.Length - 3);
                text += addText;
                text += " and " + biggerNumbers[biggerNumbers.Count - 1];
                text += " have the same maximal frequence(each occurs " + countBackUp + " times). The leftmost of them is " + leftNumber;
                File.AppendAllText("output.txt", text);
                File.AppendAllText("output.txt", Environment.NewLine);
                biggerNumbers.Clear();
                countBackUp = 1;
            }
        }
    }
}