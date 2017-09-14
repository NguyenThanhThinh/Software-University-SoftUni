using System;

public class Tiger : Felime
{
    public Tiger(string name, double weight, string type, string livingRegion) 
        : base(name, weight, type, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            FoodEaten = food.Quantity;
        }
        else
        {
            throw new ArgumentException("Tigers are not eating that type of food!");
        }
    }
}