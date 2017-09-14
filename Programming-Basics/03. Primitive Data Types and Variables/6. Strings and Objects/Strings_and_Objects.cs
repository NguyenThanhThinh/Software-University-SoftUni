using System;

class Strings_and_Objects
{
    static void Main()
    {
        string Hello = "Hello";
        string World = "World";

        object HelloWorld = Hello + " " + World;

        Console.WriteLine(HelloWorld);

        string TypeCasting = (String)HelloWorld;

        Console.WriteLine(TypeCasting);
    }
}
