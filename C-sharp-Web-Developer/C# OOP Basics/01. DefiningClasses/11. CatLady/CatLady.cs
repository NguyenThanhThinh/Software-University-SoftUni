using System;
using System.Collections.Generic;
using System.Linq;

public class CatLady
{
    public static void Main()
    {
        var cats = new Dictionary<string, Dictionary<string, double>>();
        var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        while (!input[0].Equals("End"))
        {
            var breed = input[0];
            var name = input[1];
            var value = double.Parse(input[2]);

            if (!cats.ContainsKey(breed))
            {
                cats[breed] = new Dictionary<string, double>();
                cats[breed][name] = value;
            }
            else
            {
                cats[breed][name] = value;
            }

            input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        var wantedCat = Console.ReadLine();

        var takeWantedCat =
            cats
                .FirstOrDefault(breed => breed.Value.Any(cat => cat.Key.Equals(wantedCat)))
                .Value
                .FirstOrDefault(cat => cat.Key.Equals(wantedCat));

        var wantedCatBreed =
            cats
                .FirstOrDefault(breed => breed.Value.Any(cat => cat.Key.Equals(wantedCat))).Key;

        var catbum =
            cats.Where(c => c.Value.ContainsKey(wantedCat)).ToDictionary(t => t.Key, t => t.Value);

        if (catbum.Any(name => name.Value.Any(k => k.Key.Equals(wantedCat))))
        {
            
        }

        //if (wantedCatBreed.Equals("Cymric"))
        //{
        //    Console.WriteLine($"{wantedCatBreed} {takeWantedCat.Key} {takeWantedCat.Value:F2} ");
        //}
        //else
        //{
        //    Console.WriteLine($"{wantedCatBreed} {takeWantedCat.Key} {takeWantedCat.Value} ");
        //}
    }
}