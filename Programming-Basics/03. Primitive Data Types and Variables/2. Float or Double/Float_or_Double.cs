using System;

class Float_or_Double
{
    static void Main()
    {
        Console.WriteLine("This is what we need to see down:");
        Console.WriteLine("34.567839023 \n12.345 \n8923.1234857 \n3456.091\n \nThis is the result:\n");

        double one = 34.567839023;
        float two = 12.345f;
        double tree = 8923.1234857;
        float four = 3456.091f;

        Console.WriteLine("{0} \n{1} \n{2} \n{3}\n", one, two, tree, four);
    }
}
