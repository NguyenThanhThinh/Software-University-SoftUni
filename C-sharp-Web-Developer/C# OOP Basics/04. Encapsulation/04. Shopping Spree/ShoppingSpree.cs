using System;
using System.Collections.Generic;
using System.Text;

public class ShoppingSpree
{

    public static void Main()
    {
        var allPeople = new List<Person>();
        var allProducts = new List<Product>();
        StringBuilder result = new StringBuilder();

        var people = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            for (int stuff = 0; stuff < people.Length; stuff++)
            {
                var peopleAndMoneySplit = people[stuff].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var name = peopleAndMoneySplit[0];
                double money = double.Parse(peopleAndMoneySplit[1]);

                allPeople.Add(new Person(name, money));
            }

            var products = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int produc = 0; produc < products.Length; produc++)
            {
                var productsAndMoneySplit = products[produc].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var productName = productsAndMoneySplit[0];
                double productPrice = double.Parse(productsAndMoneySplit[1]);

                allProducts.Add(new Product(productName, productPrice));
            }

            var personBuyProduct = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!personBuyProduct[0].Equals("END"))
            {
                CustomerIsBuyingTheProductOrSaysNoMoney(allPeople, allProducts, personBuyProduct, result);

                personBuyProduct = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            GetAllPeopleProductsAndAddToResult(allPeople, result);
            Console.WriteLine(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    private static void GetAllPeopleProductsAndAddToResult(List<Person> allPeople, StringBuilder result)
    {
        foreach (var person in allPeople)
        {
            if (person.BagOfProducts.Count == 0)
            {
                result.AppendLine($"{person.Name} - Nothing bought");
            }
            else
            {
                result.AppendLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
            }
        }
    }

    private static void CustomerIsBuyingTheProductOrSaysNoMoney(List<Person> allPeople, List<Product> allProducts,
        string[] personBuyProduct, StringBuilder result)
    {
        var personIndex = allPeople.FindIndex(p => p.Name.Equals(personBuyProduct[0]));
        var productIndex = allProducts.FindIndex(p => p.Name.Equals(personBuyProduct[1]));

        if (personIndex >= 0)
        {
            if (allPeople[personIndex].Money >= allProducts[productIndex].Cost)
            {
                allPeople[personIndex].Money -= allProducts[productIndex].Cost;
                allPeople[personIndex].BagOfProducts.Add(personBuyProduct[1]);
                result.AppendLine($"{allPeople[personIndex].Name} bought {allProducts[productIndex].Name}");
            }
            else
            {
                result.AppendLine($"{allPeople[personIndex].Name} can't afford {allProducts[productIndex].Name}");
            }
        }
    }
}