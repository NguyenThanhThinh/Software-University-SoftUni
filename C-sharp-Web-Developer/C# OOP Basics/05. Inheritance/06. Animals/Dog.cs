using System;

public class Dog : Animal, ISound
{
    public Dog(string name, int age, string gender) 
        : base(name, age, gender)
    {
    }

    public string GetAnimalSound()
    {
        return "BauBau";
    }

    public override string ToString()
    {
        return String.Format($"Dog{Environment.NewLine}{base.ToString()}{Environment.NewLine}{GetAnimalSound()}");
    }
}