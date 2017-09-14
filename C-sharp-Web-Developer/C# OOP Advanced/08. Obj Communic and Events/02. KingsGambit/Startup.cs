using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var kingName = Console.ReadLine();
        var king = new King(kingName);
        var royalGuards = Console.ReadLine().Split();
        List<IAttackable> servants = new List<IAttackable>();

        foreach (var royalGuard in royalGuards)
        {
            servants.Add(new RoyalGuard(royalGuard));
        }

        var footmen = Console.ReadLine().Split();

        foreach (var footman in footmen)
        {
            servants.Add(new Footman(footman));
        }

        servants.ForEach(s => king.UnderAttack += s.OnKingUnderAttack);
        var line = Console.ReadLine().Split();

        while (!line[0].Equals("End"))
        {
            var command = line[0];
            var name = line[1];

            switch (command)
            {
                case "Kill":
                    var servantToRemove = servants.First(s => s.Name.Equals(name));
                    king.UnderAttack -= servantToRemove.OnKingUnderAttack;
                    servants.Remove(servantToRemove);
                    break;
                case "Attack":
                    king.RespondToAttack();
                    break;
            }
            line = Console.ReadLine().Split();
        }
    }
}