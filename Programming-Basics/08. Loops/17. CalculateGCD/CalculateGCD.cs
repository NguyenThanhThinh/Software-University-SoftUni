using System;
        
class CalculateGCD
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        int firstHolder = 0;
        int secondHolder = 0;

        while (a != 0 && b != 0)
        {
            firstHolder = a / b;
            secondHolder = a % b;
            firstHolder = (b * firstHolder) + secondHolder;
            a = b;
            b = secondHolder;
        }
        Console.WriteLine(a > b ? a : b);
    }
}