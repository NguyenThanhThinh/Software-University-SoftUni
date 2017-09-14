namespace Debugging_Substring
{
    using System;
    using System.Text;

    public class Substring_broken
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int jump = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            char search = 'p';
            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == search)
                {
                    hasMatch = true;

                    int endIndex = jump;

                    if (i + endIndex >= text.Length)
                    {
                        endIndex = text.Length - i - 1;
                    }

                    string matchedString = text.Substring(i, endIndex + 1);
                    result.AppendLine(matchedString);
                    i += jump;
                }
            }

            if (!hasMatch)
            {
                result.AppendLine("no");
            }

            Console.WriteLine(result);
        }
    }
}
