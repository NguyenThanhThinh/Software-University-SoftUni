using System;
using System.Collections.Generic;
using System.Linq;

public class PokemonTrainer
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var trainers = new Dictionary<string, Trainer>();

        while (!input[0].Equals("Tournament"))
        {
            var trainerName = input[0];
            if (!trainers.ContainsKey(trainerName))
            {
                trainers[trainerName] = new Trainer(trainerName);
            }
            var pokemon = new Pokemon(input[1], input[2], double.Parse(input[3]));
            trainers[trainerName].pokemons.Add(pokemon);

            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        string command = Console.ReadLine();

        while (!command.Equals("End"))
        {
            switch (command)
            {
                case "Fire":
                    ModifyAllTrainersDepenceIfTheyHaveSpecificDragonType(trainers, command);
                    break;
                case "Water":
                    ModifyAllTrainersDepenceIfTheyHaveSpecificDragonType(trainers, command);
                    break;
                case "Electricity":
                    ModifyAllTrainersDepenceIfTheyHaveSpecificDragonType(trainers, command);
                    break;
            }
            command = Console.ReadLine();
        }

        foreach (var trainer in trainers.OrderByDescending(b => b.Value.numberOfBadges))
        {
            Console.WriteLine($"{trainer.Key} {trainer.Value.numberOfBadges} {trainer.Value.pokemons.Count}");
        }
    }

    private static void ModifyAllTrainersDepenceIfTheyHaveSpecificDragonType(Dictionary<string, Trainer> trainers, string command)
    {
        foreach (var trainer in trainers)
        {
            if (trainer.Value.pokemons.Any(p => p.element.Equals(command)))
            {
                trainer.Value.numberOfBadges += 1;
            }
            else
            {
                foreach (var pokemon in trainer.Value.pokemons)
                {
                    pokemon.health -= 10;
                }
                trainer.Value.pokemons.RemoveAll(p => p.health <= 0);
            }
        }
    }
}