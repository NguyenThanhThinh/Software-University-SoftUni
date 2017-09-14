using System;
using System.Linq;

public class TheHeiganDance
{
    public static void Main()
    {
        double damageToHeigan = double.Parse(Console.ReadLine());
        double playerHealth = 18500d;
        double heiganHealth = 3000000d;
        int[] playerRowAndCol = new int[2];
        playerRowAndCol[0] = 7;
        playerRowAndCol[1] = 7;
        bool[] cloudSpellHitted = new bool[1];
        bool playerKilledByCloudSpellSecondDamage = false;
        string lastSpellName = string.Empty;

        while (true)
        {
            var spellStats = Console.ReadLine().Split().ToArray();
            string spellName = spellStats[0];
            int spellRow = int.Parse(spellStats[1]);
            int spellCol = int.Parse(spellStats[2]);

            heiganHealth -= damageToHeigan;

            if (cloudSpellHitted[0])
            {
                playerHealth -= 3500;
                if (playerHealth <= 0)
                {
                    playerKilledByCloudSpellSecondDamage = true;
                }
                cloudSpellHitted[0] = false;
            }

            if (heiganHealth <= 0)
            {
                if (playerHealth <= 0)
                {
                    Console.WriteLine($"Heigan: Defeated!");
                    var killedBy = playerKilledByCloudSpellSecondDamage ? "Plague Cloud" : $"{lastSpellName}";
                    Console.WriteLine($"Player: Killed by {killedBy}");
                    Console.WriteLine($"Final position: {playerRowAndCol[0]}, {playerRowAndCol[1]}");
                    break;
                }
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: {playerHealth}");
                Console.WriteLine($"Final position: {playerRowAndCol[0]}, {playerRowAndCol[1]}");
                break;
            }
            if (playerHealth <= 0)
            {
                PerformActionWhenPlayerIsDead(heiganHealth, lastSpellName, playerKilledByCloudSpellSecondDamage, playerRowAndCol);
                break;
            }

            if (spellName.Equals("Cloud"))
            {
                playerHealth = HeiganAttacksWithCloudSpell(playerRowAndCol, playerHealth, spellRow, spellCol, cloudSpellHitted);
                lastSpellName = "Plague Cloud";
            }
            else if (spellName.Equals("Eruption"))
            {
                playerHealth = HeiganAttacksWithEruptionSpell(playerRowAndCol, playerHealth, spellRow, spellCol);
                lastSpellName = "Eruption";
            }

            if (playerHealth <= 0)
            {
                PerformActionWhenPlayerIsDead(heiganHealth, lastSpellName, playerKilledByCloudSpellSecondDamage, playerRowAndCol);
                break;
            }
        }
    }

    private static void PerformActionWhenPlayerIsDead(double heiganHealth, string lastSpellName, bool playerKilledByCloudSpellSecondDamage, int[] playerRowAndCol)
    {
        Console.WriteLine($"Heigan: {heiganHealth:F2}");
        var killedBy = playerKilledByCloudSpellSecondDamage ? "Plague Cloud" : $"{lastSpellName}";
        Console.WriteLine($"Player: Killed by {killedBy}");
        Console.WriteLine($"Final position: {playerRowAndCol[0]}, {playerRowAndCol[1]}");
    }

    private static double HeiganAttacksWithEruptionSpell(int[] playerRowAndCol, double playerHealth, int spellRow, int spellCol)
    {
        bool playerEscaped = true;
        double health = playerHealth;

        if (CheckIfPlayerIsInDamageArea(playerRowAndCol[0], playerRowAndCol[1], spellRow, spellCol))
        {
            playerEscaped = CheckIfPlayerCanEscapeFromDamageArea(playerRowAndCol, spellRow, spellCol);
        }
        //If player Escaped Successfully  we do not take from  his health. If the return is False we take the needed damage and return the new sum
        if (playerEscaped)
        {
            return health;
        }
        else
        {
            health -= 6000;
            return health;
        }
    }

    private static double HeiganAttacksWithCloudSpell(int[] playerRowAndCol, double playerHealth, int spellRow, int spellCol, bool[] cloudSpellHitted)
    {
        bool playerEscaped = true;
        double health = playerHealth;

        if (CheckIfPlayerIsInDamageArea(playerRowAndCol[0], playerRowAndCol[1], spellRow, spellCol))
        {
            playerEscaped = CheckIfPlayerCanEscapeFromDamageArea(playerRowAndCol, spellRow, spellCol);
        }
        //If player Escaped Successfully  we do not take from  his health. If the return is False we take the needed damage and return the new sum
        if (playerEscaped)
        {
            return health;
        }
        else
        {
            health -= 3500;
            cloudSpellHitted[0] = true;
            return health;
        }
    }

    private static bool CheckIfPlayerCanEscapeFromDamageArea(int[] playerRowAndCol, int spellRow, int spellCol)
    {
        //With all the conditions here, we check all possible ways the player to Escape, and if that's True we change his Current Position
        if (!CheckIfPlayerIsInDamageArea(playerRowAndCol[0] - 1, playerRowAndCol[1], spellRow, spellCol))
        {
            playerRowAndCol[0]--;
            return true;
        }
        if (!CheckIfPlayerIsInDamageArea(playerRowAndCol[0], playerRowAndCol[1] + 1, spellRow, spellCol))
        {
            playerRowAndCol[1]++;
            return true;
        }
        if (!CheckIfPlayerIsInDamageArea(playerRowAndCol[0] + 1, playerRowAndCol[1], spellRow, spellCol))
        {
            playerRowAndCol[0]++;
            return true;
        }
        if (!CheckIfPlayerIsInDamageArea(playerRowAndCol[0], playerRowAndCol[1] - 1, spellRow, spellCol))
        {
            playerRowAndCol[1]--;
            return true;
        }
        return false;
    }

    private static bool CheckIfPlayerIsInDamageArea(int playerRow, int playerCol, int spellRow, int spellCol)
    {
        //check if player is outside the chamber and if YES return True so he can't escape that way
        if (playerRow < 0 || playerRow >= 15 || playerCol < 0 || playerCol >= 15)
        {
            return true;
        }

        //If player is in damager area with the new move, return True so in the previous method no Escaped will be force
        if (spellRow == playerRow || spellRow + 1 == playerRow || spellRow - 1 == playerRow)
        {
            if (spellCol == playerCol || spellCol + 1 == playerCol || spellCol - 1 == playerCol)
            {
                return true;
            }
        }
        //If non of the above return True, player Escaped successfully
        return false;
    }
}