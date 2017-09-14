using System;
using System.Collections.Generic;
using System.Linq;

public class WildfarmMain
{
    public static Animal animal;
    public static void Main()
    {
        var animalInfo = new List<string>();
        var food = new List<string>();

        string animalType = String.Empty;
        string animalName = String.Empty;
        double animalWeight;
        string animalLivingRegion = String.Empty;
        string catBreed = String.Empty;
       
        animalInfo = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        
        while (!animalInfo[0].Equals("End"))
        {
            food = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            animalType = animalInfo[0];
            animalName = animalInfo[1];
            animalWeight = double.Parse(animalInfo[2]);
            animalLivingRegion = animalInfo[3];

            var curentFood = GetCurrentFood(food);

            try
            {
                if (animalInfo.Count > 4)
                {
                    catBreed = animalInfo[4];
                    animal = new Cat(animalName, animalWeight, animalType, animalLivingRegion, catBreed);
                }
                else
                {
                    animal = GetCurrentAnimal(animalType, animalName, animalWeight, animalLivingRegion);
                }
                animal.MakeSound();
                animal.Eat(curentFood);
                Console.WriteLine(animal);
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
                Console.WriteLine(animal);
            }

            animalInfo = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }

    private static Animal GetCurrentAnimal(string animalType, string animalName, double animalWeight, string animalLivingRegion)
    {
        switch (animalType)
        {
            case "Tiger":
                return new Tiger(animalName, animalWeight, animalType, animalLivingRegion);
            case "Mouse":
                return new Mouse(animalName, animalWeight, animalType, animalLivingRegion);
            case "Zebra":
                return new Zebra(animalName, animalWeight, animalType, animalLivingRegion);
            default:
                return new Mouse(animalName, animalWeight, animalType, animalLivingRegion);
                // default condition doesn't have sence in the logic, I just want to return something as I used switch instead of if/else
        }
    }

    private static Food GetCurrentFood(List<string> food)
    {
        if (food[0].Equals("Vegetable"))
        {
            return new Vegetable(int.Parse(food[1]));
        }
        else
        {
            return new Meat(int.Parse(food[1]));
        }
    }
}
