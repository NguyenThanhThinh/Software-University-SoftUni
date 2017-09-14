using System;

class Comparing_Floats
{
    static void Main()
    {
        string numberA = Console.ReadLine();
        string numberB = Console.ReadLine();
        string eps = "0.000001";
        bool biggerNumber = (numberA.Length >= eps.Length) || (numberB.Length >= eps.Length);

        if ((numberA[0] == '-' && biggerNumber) || (numberB[0] == '-' && biggerNumber))
        {
            bool equalNumber = (numberA.Length == eps.Length) && (numberB.Length == eps.Length);
            if ((numberA.LastIndexOf(numberA) != numberB.LastIndexOf(numberB)) && equalNumber)
            {
                Console.WriteLine("False");
            }
        }


    }
}

