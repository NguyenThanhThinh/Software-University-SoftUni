using System;
using System.Collections.Generic;
using System.Text;

public class AnimalClinicMain
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();
        var result = new StringBuilder();
        List<Animal> healedAnimals = new List<Animal>();
        List<Animal> rehabilitateAnimals = new List<Animal>();

        while (!input[0].Equals("End"))
        {
            string name = input[0];
            string breed = input[1];
            if (input[2].Equals("heal"))
            {
                result.AppendLine($"Patient {AnimalClinic.PatientId}: [{name} ({breed})] has been healed!");
                healedAnimals.Add(new Animal(name, breed));
                AnimalClinic.KeepTrackOfHealedAnimals();
            }
            else if (input[2].Equals("rehabilitate"))
            {
                result.AppendLine($"Patient {AnimalClinic.PatientId}: [{name} ({breed})] has been rehabilitated!");
                rehabilitateAnimals.Add(new Animal(name, breed));
                AnimalClinic.KeepTrackOfRehabilitedAnimals();
            }

            input = Console.ReadLine().Split();
        }

        string command = Console.ReadLine();

        result.AppendLine($"Total healed animals: {AnimalClinic.HealedAnimalsCount}");
        result.AppendLine($"Total rehabilitated animals: {AnimalClinic.RehabilitedAnimalsCount}");

        if (command.Equals("heal"))
        {
            foreach (var animal in healedAnimals)
            {
                result.AppendLine($"{animal.Name} {animal.Breed}");
            }
        }
        else
        {
            foreach (var animal in rehabilitateAnimals)
            {
                result.AppendLine($"{animal.Name} {animal.Breed}");
            }
        }

        Console.WriteLine(result);
    }
}