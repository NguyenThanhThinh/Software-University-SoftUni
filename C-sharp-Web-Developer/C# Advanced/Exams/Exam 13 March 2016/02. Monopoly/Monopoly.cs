using System;
using System.Linq;

public class Monopoly
{
    public static void Main()
    {
        var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[][] gameField = new char[dimensions[0]][];

        for (int i = 0; i < dimensions[0]; i++)
        {
            gameField[i] = Console.ReadLine().ToCharArray();
        }

        int turns = 0;
        int hotels = 0;
        int money = 50;
        int moneySpend = 0;

        for (int row = 0; row < gameField.GetLength(0); row++)
        {
            if (row % 2 != 0)
            {
                for (int col = gameField[row].Length - 1; col >= 0; col--)
                {
                    MoveOneTurnAndPlayTheGame(gameField, ref turns, ref hotels, ref money, ref moneySpend, row, col);
                    money += hotels * 10;
                    turns++;
                }
            }
            else
            {
                for (int col = 0; col < gameField[row].Length; col++)
                {
                    MoveOneTurnAndPlayTheGame(gameField, ref turns, ref hotels, ref money, ref moneySpend, row, col);
                    money += hotels * 10;
                    turns++;
                }
            }
        }
        Console.WriteLine($"Turns {turns}");
        Console.WriteLine($"Money {money}");
    }

    private static void MoveOneTurnAndPlayTheGame(char[][] gameField, ref int turns, ref int hotels, ref int money, ref int moneySpend, int row, int col)
    {
        char sign = gameField[row][col];
        if (sign.Equals('H'))
        {
            hotels++;
            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
            money = 0;
        }
        else if (sign.Equals('J'))
        {
            Console.WriteLine($"Gone to jail at turn {turns}.");
            turns += 2;
            money += (hotels * 10) * 2;
        }
        else if (sign.Equals('S'))
        {
            moneySpend = (row + 1) * (col + 1);
            int oldMoney = money;
            money -= moneySpend;
            if (money < 0)
            {
                money = oldMoney;
                Console.WriteLine($"Spent {oldMoney} money at the shop.");
                oldMoney = 0;
                money = 0;
            }
            else
            {
                if (moneySpend > oldMoney)
                {
                    Console.WriteLine($"Spent {money} money at the shop.");
                }
                else
                {
                    Console.WriteLine($"Spent {moneySpend} money at the shop.");
                }
            }
        }
    }
}