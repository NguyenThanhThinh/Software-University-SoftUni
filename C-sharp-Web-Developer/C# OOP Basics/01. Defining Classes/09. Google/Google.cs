using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Google
{
    public static void Main()
    {
        var data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var persons = new Dictionary<string, Person>();

        while (!data[0].Equals("End"))
        {
            string name = data[0];
            if (!persons.ContainsKey(name))
            {
                persons[data[0]] = new Person(name);
            }
            Console.WriteLine(persons);
            switch (data[1])
            {
                case "company":
                    var company = new Company(data[2], data[3], double.Parse(data[4]));
                    persons[name].Company = company;
                    break;
                case "pokemon":
                    var pokemon = new Pokemon(data[2], data[3]);
                    persons[name].Pokemon.Add(pokemon);
                    break;
                case "parents":
                    var parents = new Parents(data[2], DateTime.ParseExact(data[3], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    persons[name].Parents.Add(parents);
                    break;
                case "children":
                    var children = new Children(data[2], DateTime.ParseExact(data[3], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    persons[name].Children.Add(children);
                    break;
                case "car":
                    var car = new Car(data[2], double.Parse(data[3]));
                    persons[name].Car = car;
                    break;
            }

            data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        var searchedPerson = Console.ReadLine();

        var result = persons.Where(p => p.Key.Equals(searchedPerson));

        foreach (var singlePerson in result)
        {
            Console.WriteLine(singlePerson.Key);
            Console.WriteLine(singlePerson.Value.Company.Name.Length > 0
                ? $"Company: {Environment.NewLine}{singlePerson.Value.Company.Name} {singlePerson.Value.Company.Department} {singlePerson.Value.Company.Salary:F2}"
                : "Company:");
            Console.WriteLine(singlePerson.Value.Car.Model.Length > 0
                ? $"Car: {Environment.NewLine}{singlePerson.Value.Car.Model} {singlePerson.Value.Car.Speed}"
                : "Car:");
            Console.WriteLine("Pokemon:");
            if (singlePerson.Value.Pokemon.Count > 0)
            {
                foreach (var pokemon in singlePerson.Value.Pokemon)
                {
                    Console.WriteLine($"{pokemon.Name} {pokemon.Type}");
                }
            }
            Console.WriteLine("Parents:");
            if (singlePerson.Value.Parents.Count > 0)
            {
                foreach (var parents in singlePerson.Value.Parents)
                {
                    Console.WriteLine($"{parents.Name} {parents.BirthDay.ToString("dd/MM/yyyy")}");
                }
            }
            Console.WriteLine("Children:");
            if (singlePerson.Value.Parents.Count > 0)
            {
                foreach (var children in singlePerson.Value.Children)
                {
                    Console.WriteLine($"{children.Name} {children.BirthDay.ToString("dd/MM/yyyy")}");
                }
            }
        }
    }
}