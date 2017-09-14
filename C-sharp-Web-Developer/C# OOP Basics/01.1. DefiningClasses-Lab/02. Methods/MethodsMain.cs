using System;

public class MethodsMain
{
    public static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.Id = 1;
        acc.Deposit(15);
        acc.Windraw(5);

        Console.WriteLine(acc.ToString());
    }
}
