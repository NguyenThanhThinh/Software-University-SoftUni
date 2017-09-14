using System;
using System.Collections.Generic;
using System.Linq;

public class VladkoNotebook
{
    public static void Main()
    {
        var input = Console.ReadLine().Split('|');
        var opponentsBook = new List<Opponents>();
        var opponent = new Opponents();
        string color = string.Empty;
        string name = string.Empty;
        string currentOpponent = string.Empty;
        int age = 0;
        bool win = false;
        bool ageHasValue = false;
        bool winLossHasValue = false;
        bool nameHasValue = false;

        while (!input[0].Equals("END"))
        {
            color = input[0];
            var middleValue = input[1];
            var lastValue = input[2].Trim();

            if (middleValue.Equals("age"))
            {
                age = int.Parse(lastValue);
                ageHasValue = true;
            }
            else if (middleValue.Equals("win") || middleValue.Equals("loss"))
            {
                if (middleValue.Equals("win"))
                {
                    win = true;
                }
                currentOpponent = lastValue;
                winLossHasValue = true;
            }
            else if (middleValue.Equals("name"))
            {
                name = lastValue;
                nameHasValue = true;
            }

            // from here we start to add the current players and there values to the Opponents Class

            // if the opponent with that color is missing, create it
            if (!opponentsBook.Any(o => o.Color.Equals(color)))
            {
                opponent.Color = color;
                opponentsBook.Add(opponent);
                opponent = new Opponents();
            }

            // then add all the given values from the current line
            var searchedOpponent = opponentsBook.First(o => o.Color.Equals(color));
            int opponentIndex = opponentsBook.IndexOf(searchedOpponent);

            if (ageHasValue)
            {
                opponentsBook[opponentIndex].Age = age;
                ageHasValue = false;
            }
            else if (winLossHasValue)
            {
                opponentsBook[opponentIndex].OpponentsList.Add(currentOpponent);
                if (win)
                {
                    opponentsBook[opponentIndex].Wins += 1;
                    win = false;
                }
                else
                {
                    opponentsBook[opponentIndex].Losses += 1;
                }
                winLossHasValue = false;
            }
            else if (nameHasValue)
            {
                opponentsBook[opponentIndex].Name = name;
                nameHasValue = false;
            }

            input = Console.ReadLine().Split('|');
        }

        IComparer<Opponents> comparer = new MyOrderingClass();
        opponentsBook.Sort(comparer);
        var test = opponentsBook.Where(n => n.Age > 0 && !(n.Name.Equals(string.Empty)));

        if (test.Count() == 0)
        {
            Console.WriteLine("No data recovered.");
        }

        var compareOrdinal = StringComparer.Ordinal;

        foreach (var item in test)
        {
            Console.WriteLine($"Color: {item.Color}");
            Console.WriteLine($"-age: {item.Age}");
            Console.WriteLine($"-name: {item.Name}");
            if (item.OpponentsList.Count > 0)
            {
                var people = item.OpponentsList.ToArray();
                Array.Sort(people, StringComparer.Ordinal);
                Console.WriteLine($"-opponents: {string.Join(", ", people)}");
            }
            else
            {
                Console.WriteLine("-opponents: (empty)");
            }
            Console.WriteLine($"-rank: {item.Wins / item.Losses:F2}");
        }
    }
}