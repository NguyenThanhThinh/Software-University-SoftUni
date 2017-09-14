using System;

class PlayWithIntDoubleString
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> int" + Environment.NewLine + "2-- > double" + Environment.NewLine + "3-- > string");

        int choise = int.Parse(Console.ReadLine());

        switch (choise)
        {
            case 1:
                Console.Write("Please enter a int: ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(number + 1);
                break;
            case 2:
                Console.Write("Please enter a double: ");
                double realNumber = double.Parse(Console.ReadLine());
                Console.WriteLine(realNumber + 1);
                break;
            case 3:
                Console.Write("Please enter a string: ");
                string stringNumber = Console.ReadLine();
                Console.WriteLine(stringNumber + "*");
                break;
            default:
                break;
        }
    }
}
