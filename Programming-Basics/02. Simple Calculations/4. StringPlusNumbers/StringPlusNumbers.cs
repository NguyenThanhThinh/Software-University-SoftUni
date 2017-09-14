using System;

class StringPlusNumbers
{
    static void Main()
    {
        string name = Console.ReadLine();
        string lastName = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string city = Console.ReadLine();

        Console.WriteLine("You are {0} {1}, a {2}-years old person from {3}. ", name, lastName, age, city);
    
    }
}
