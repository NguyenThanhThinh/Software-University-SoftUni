using System;

public class Frog : Animal, ISound
{
    public Frog(string name, int age, string gender)
       : base(name, age, gender)
    {
    }

    public string GetAnimalSound()
    {
        return "Frogggg";
    }

    public override string ToString()
    {
        return String.Format($"Frog{Environment.NewLine}{base.ToString()}{Environment.NewLine}{GetAnimalSound()}");
    }
}