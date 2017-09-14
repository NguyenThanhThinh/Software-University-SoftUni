using System;

public static class ActionPrint
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Action<string> myAction = Print;
        myAction(input);
    }

    public static void Print(string input)
    {
        var splitNames = input.Split();
        foreach (var name in splitNames)
        {
            Console.WriteLine(name);
        }
    }
}