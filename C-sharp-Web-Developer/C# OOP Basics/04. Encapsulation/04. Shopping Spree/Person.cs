using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private double money;
    private List<string> bagOfProducts;

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.BagOfProducts = new List<string>();
    }

    public string Name
    {
        get { return name; }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public double Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public List<string> BagOfProducts
    {
        get { return bagOfProducts; }
        set { bagOfProducts = value; }
    }
}