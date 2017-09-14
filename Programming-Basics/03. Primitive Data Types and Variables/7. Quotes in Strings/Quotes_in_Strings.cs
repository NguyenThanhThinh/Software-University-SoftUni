using System;

class Quotes_in_Strings
{
    static void Main()
    {
        string one = "The \"use\" of quotations causes difficulties.";
        string two = @"The ""use"" of quotations causes difficulties.";

        Console.WriteLine("{0} \n{1}", one, two);
    }
}
