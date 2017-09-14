using System;
using System.Linq;

public static class PredicateForNames
{
    public static void Main()
    {
        int lenght = int.Parse(Console.ReadLine());
        var names = Console.ReadLine().Split().ToList();
        Predicate<string> namesByLenght = n => n.Length <= lenght;
        var foundedNames = names.FindAll(namesByLenght);
        foundedNames.ForEach(n => Console.WriteLine(n));
    }
}