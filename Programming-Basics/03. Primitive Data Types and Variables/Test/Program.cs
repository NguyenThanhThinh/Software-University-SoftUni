using System;
class Program
{
    static void Main()
    {
        decimal a = 30000m;
        a = ((a / 2) / 60) / 60;
        Console.WriteLine(((a / 2) / 60) / 60);

        decimal b = 2.5M;
        Console.WriteLine(b);
    }
}
