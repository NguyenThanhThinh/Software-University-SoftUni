using System;

public class Tomcat : Cat
{
    //Tomcats are male
    public Tomcat(string name, int age) 
        : base(name, age, "Male")
    {
    }

    public override string GetAnimalSound()
    {
        return "Give me one million b***h";
    }

    public override string ToString()
    {
        return String.Format($"Tomcat{Environment.NewLine}{base.ToString()}{Environment.NewLine}{GetAnimalSound()}");
    }
}