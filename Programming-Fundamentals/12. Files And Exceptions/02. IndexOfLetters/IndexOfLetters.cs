using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class IndexOfLetters
{
    static void Main()
    {
        List<string> letters = new List<string>();
        StringBuilder line = new StringBuilder();

        for (int i = 97; i <= 122; i++)
        {
            char sign = (char)i;
            letters.Add(sign.ToString());
        }

        var input = File.ReadAllLines(@"../../input.txt");

        for (int i = 0; i < input.Length; i++)
        {
            for (int p = 0; p < input[i].Length; p++)
            {
                string currentChar = input[i][p].ToString();
                string indexOfChar = letters.IndexOf(currentChar).ToString();

                if (indexOfChar != "-1")
                {
                    line.Append(currentChar + " -> " + indexOfChar);
                    line.AppendLine();
                    File.AppendAllText(@"../../output.txt", line.ToString());
                    line.Clear();
                }
            }
            File.AppendAllText(@"../../output.txt", Environment.NewLine);
        }
    }
}