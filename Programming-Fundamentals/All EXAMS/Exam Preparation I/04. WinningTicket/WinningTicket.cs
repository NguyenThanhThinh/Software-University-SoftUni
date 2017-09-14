using System;
using System.Text.RegularExpressions;

class WinningTicket
{
    static void Main(string[] args)
    {
        var tickets = Console.ReadLine().Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (tickets.Length == 0)
        {
            Console.WriteLine($"ticket \"\" - no match");
        }

        for (int i = 0; i < tickets.Length; i++)
        {
            var ticket = tickets[i];
            if (ticket.Length != 20)
            {
                Console.WriteLine("invalid ticket");
                continue;
            }

            var leftSide = ticket.Substring(0, 10);
            var rightSide = ticket.Substring(10, 10);

            string pattern = @"[@#$\^]{6,}";

            Regex leftSideRegex = new Regex(pattern);
            Match leftSideMatch = leftSideRegex.Match(leftSide);

            Regex rightSideRegex = new Regex(pattern);
            Match rightSideMatch = rightSideRegex.Match(rightSide);

            if (leftSideMatch.Success && rightSideMatch.Success)
            {
                if (leftSideMatch.Value[0] == rightSideMatch.Value[0])
                {
                    if (leftSideMatch.Length == 10 && rightSideMatch.Length == 10)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - 10{leftSideMatch.Value[0]} Jackpot!");
                    }
                    else
                    {
                        var bam = leftSideMatch.Length < rightSideMatch.Length ? leftSideMatch.Length : rightSideMatch.Length;
                        Console.WriteLine($"ticket \"{ticket}\" - {bam}{leftSideMatch.Value[0]}");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
            else
            {
                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }
        }
    }
}