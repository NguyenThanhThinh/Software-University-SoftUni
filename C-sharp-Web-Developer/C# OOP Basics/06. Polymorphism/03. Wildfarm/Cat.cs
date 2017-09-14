﻿using System;

public class Cat : Felime
{
    private string bread;

    public Cat(string name, double weight, string type, string livingRegion, string bread)
        : base(name, weight, type, livingRegion)
    {
        this.bread = bread;
    }

    private string Bread
    {
        get { return this.bread; }
        set { this.bread = value; }
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }

    public override void Eat(Food food)
    {
        FoodEaten = food.Quantity;
    }

    public override string ToString()
    {
        return string.Format(
            $"{GetType().FullName}[{Name}, {bread}, {Weight}, {LivingRegion}, {FoodEaten}]");
    }
}