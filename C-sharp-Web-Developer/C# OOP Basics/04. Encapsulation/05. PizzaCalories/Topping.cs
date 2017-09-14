using System;
using System.Linq;

public class Topping
{
    private readonly string[] TypesArray = { "meat", "veggies", "cheese", "sauce" };

    private string type;

    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    private string Type
    {
        set
        {
            if (!TypesArray.Contains(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    private double Weight
    {
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public double CalculateCalories()
    {
        switch (type.ToLower())
        {
            case "meat":
                return weight * 2 * 1.2d;
            case "veggies":
                return weight * 2 * 0.8d;
            case "cheese":
                return weight * 2 * 1.1d;
            case "sauce":
                return weight * 2 * 0.9d;
        }
        return 0d;
    }
}