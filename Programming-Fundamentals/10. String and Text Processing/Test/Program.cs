using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomCharacters = Console.ReadLine();
            var pattern = Console.ReadLine();

            var messages = new StringBuilder();

            if (pattern.Length == 0)
            {
                Console.WriteLine("No shake.");
                Console.WriteLine(randomCharacters);
                return;
            }

            while (true)
            {
                var firstOccureence = randomCharacters.IndexOf(pattern);
                var lastOccureence = randomCharacters.LastIndexOf(pattern);

                if (firstOccureence > -1 && lastOccureence > -1 && pattern.Length > 0)
                {
                    randomCharacters = randomCharacters.Remove(lastOccureence, pattern.Length);
                    randomCharacters = randomCharacters.Remove(firstOccureence, pattern.Length);
                    messages.AppendLine("Shaked it.");

                    pattern = pattern.Remove(pattern.Length / 2, 1);

                }
                else
                {
                    messages.AppendLine("No shake.");
                    break;
                }

            }

            Console.Write(messages.ToString());
            Console.WriteLine(randomCharacters);
        }
    }
}