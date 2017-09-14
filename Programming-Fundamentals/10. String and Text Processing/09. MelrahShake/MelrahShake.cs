using System;

class MelrahShake
{
    static void Main()
    {
        string line = Console.ReadLine();
        string pattern = Console.ReadLine();

        if (pattern.Length == 0)
        {
            Console.WriteLine("No shake.");
            Console.WriteLine(line);
            return;
        }

        while (true)
        {
            int firstOcurance = line.IndexOf(pattern);
            int lastOcurance = line.LastIndexOf(pattern);

            if (firstOcurance > -1 && lastOcurance > -1 && pattern.Length > 0)
            {
                line = line.Remove(lastOcurance, pattern.Length);
                line = line.Remove(firstOcurance, pattern.Length);
                Console.WriteLine("Shaked it.");
            }
            else
            {
                Console.WriteLine("No shake.");
                Console.WriteLine(line);
                break;
            }

            int patternLenghtDivided = pattern.Length / 2;
            pattern = pattern.Remove(patternLenghtDivided, 1);
        }
    }
}