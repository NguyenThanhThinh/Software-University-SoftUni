using System;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class SoftuniAttribute : Attribute
{
    public SoftuniAttribute(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }
}