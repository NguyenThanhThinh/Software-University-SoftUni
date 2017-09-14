using System;
using System.Collections.Generic;
using System.Text;

public class BankAccountTest
{
    static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();

        var input = Console.ReadLine().Split();
        double amount;
        var sb = new StringBuilder();

        while (!input[0].Equals("End"))
        {
            try
            {
                var command = input[0];
                int id = int.Parse(input[1]);

                switch (command)
                {
                    case "Create":
                        Create(accounts, id);
                        break;
                    case "Deposit":
                        amount = double.Parse(input[2]);
                        Deposit(accounts, id, amount);
                        break;
                    case "Withdraw":
                        amount = double.Parse(input[2]);
                        WithDraw(accounts, id, amount);
                        break;
                    case "Print":
                        Print(sb, accounts, id);
                        break;
                }

                input = Console.ReadLine().Split();
            }
            catch (ArgumentException arg)
            {
                sb.AppendLine(arg.Message);
                input = Console.ReadLine().Split();
            }
        }

        Console.WriteLine(sb);
    }

    private static void Print(StringBuilder sb, Dictionary<int, BankAccount> accounts, int id)
    {
        if (accounts.ContainsKey(id))
        {
            sb.AppendLine(accounts[id].ToString());
        }
        else
        {
            throw new ArgumentException("Account does not exist");
        }
    }

    private static void WithDraw(Dictionary<int, BankAccount> accounts, int id, double amount)
    {
        if (accounts.ContainsKey(id))
        {
            accounts[id].Windraw(amount);
        }
        else
        {
            throw new ArgumentException("Account does not exist");
        }
    }

    private static void Deposit(Dictionary<int, BankAccount> accounts, int id, double amount)
    {
        if (accounts.ContainsKey(id))
        {
            accounts[id].Deposit(amount);
        }
        else
        {
            throw new ArgumentException("Account does not exist");
        }
    }

    private static void Create(Dictionary<int, BankAccount> accounts, int id)
    {
        if (!accounts.ContainsKey(id))
        {
            accounts[id] = new BankAccount();
            accounts[id].Id = id;
        }
        else
        {
            throw new ArgumentException("Account already exists");
        }
    }
}