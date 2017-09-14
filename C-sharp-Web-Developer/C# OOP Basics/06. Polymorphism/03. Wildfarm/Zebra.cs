using System;

public class Zebra : Mammal
{
    public Zebra(string name, double weight, string type, string livingRegion) 
        : base(name, weight, type, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Zs");
    }

    public override void Eat(Food food)
    {
        if (food is Vegetable)
        {
            FoodEaten = food.Quantity;
        }
        else
        {
            throw new ArgumentException("Zebras are not eating that type of food!");
        }
    }
}