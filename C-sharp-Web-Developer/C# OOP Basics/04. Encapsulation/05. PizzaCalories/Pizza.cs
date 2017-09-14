using System;
using System.Collections.Generic;

public class Pizza
{
    private string name;

    private Dough doughType;

    private List<Topping> toppings;

    private int numberOfToppings;

    public Pizza()
    {
        this.Toppings = new List<Topping>();
        this.DoughType = new Dough();
    }

    public Pizza(string name, int numberOfToppings)
    {
        this.Name = name;
        this.Toppings = new List<Topping>();
        this.NumberOfToppings = numberOfToppings;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    public Dough DoughType
    {
        set { doughType = value; }
    }

    private List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    public int NumberOfToppings
    {
        get { return numberOfToppings;  }
        private set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            numberOfToppings = value;
        }
    }

    public double GetAllCaloriesPizzaHave()
    {
        var totalCalories = doughType.CalculateCalories();

        foreach (var topping in Toppings)
        {
            totalCalories += topping.CalculateCalories();
        }

        return totalCalories;
    }

    public void AddToppingToTheList(Topping topping)
    {
        Toppings.Add(topping);
    }
}