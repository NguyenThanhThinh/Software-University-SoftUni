using System;

class Null_Values
{
    static void Main()
    {
        int? oneNull = null;
        double? secondNull = null;

        Console.WriteLine("{0}\n{1}", oneNull, secondNull);

        oneNull += 1;
        secondNull += 2;

        Console.WriteLine("{0}\n{1}", oneNull, secondNull);
          
    }
}

