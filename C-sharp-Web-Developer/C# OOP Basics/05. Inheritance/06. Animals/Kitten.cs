using System;

public class Kitten : Cat, ISound
{
    //Kittens are female 
    public Kitten(string name, int age)
        : base(name, age, "Female")
    {
    }

    public override string GetAnimalSound()
    {
        return "Miau";
    }

    public override string ToString()
    {
        return String.Format($"Kitten{Environment.NewLine}{base.ToString()}{Environment.NewLine}{GetAnimalSound()}");
    }
}