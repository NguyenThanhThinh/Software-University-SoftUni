using System.Collections.Generic;

public class Trainer
{
    public string name;
    public int numberOfBadges;
    public List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.name = name;
        this.pokemons = new List<Pokemon>();
    }
}