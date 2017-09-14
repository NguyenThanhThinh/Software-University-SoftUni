using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string type, string livingRegion) 
        : base(name, weight, type, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("SQUEEEAAAK!");
    }

    public override void Eat(Food food)
    {
        if (food is Vegetable)
        {
            FoodEaten = food.Quantity;
        }
        else
        {
            throw new ArgumentException("Mouses are not eating that type of food!");
        }
    }
}