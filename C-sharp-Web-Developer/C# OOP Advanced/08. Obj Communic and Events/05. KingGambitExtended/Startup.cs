using System;

public class Startup
{
    public static void Main()
    {
        var king = new King(Console.ReadLine());
        ModifiedDictionary soldiersByName = new ModifiedDictionary();

        var royalGuards = Console.ReadLine().Split();
        foreach (var guardName in royalGuards)
        {
            RoyalGuard newGuard = new RoyalGuard(guardName);
            soldiersByName.Add(guardName, newGuard);
            newGuard.SoldierDeath += soldiersByName.HandleSoldierDeath;
            newGuard.SoldierDeath += king.OnSoldierDeath;
            king.UnderAttack += newGuard.OnKingUnderAttack;
        }

        var footmen = Console.ReadLine().Split();
        foreach (var footmanName in footmen)
        {
            Footman newFootman = new Footman(footmanName);
            soldiersByName.Add(footmanName, newFootman);
            newFootman.SoldierDeath += soldiersByName.HandleSoldierDeath;
            newFootman.SoldierDeath += king.OnSoldierDeath;
            king.UnderAttack += newFootman.OnKingUnderAttack;
        }

        var line = Console.ReadLine().Split();

        while (!line[0].Equals("End"))
        {
            var command = line[0];
            var name = line[1];

            switch (command)
            {
                case "Kill":
                    Soldier soldierToRemove = soldiersByName[name];
                    soldierToRemove.RespondToAttack();
                    break;
                case "Attack":
                    king.RespondToAttack();
                    break;
            }
            line = Console.ReadLine().Split();
        }
    }
}