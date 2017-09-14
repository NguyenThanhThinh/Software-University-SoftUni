using System;

public class Cat : Animal, ISound
{
    public Cat(string name, int age, string gender) 
        : base(name, age, gender)
    {
    }

    public virtual string GetAnimalSound()
    {
        return "MiauMiau";
    }

    public override string ToString()
    {
        return String.Format($"Cat{Environment.NewLine}{base.ToString()}{Environment.NewLine}{GetAnimalSound()}");
    }
}