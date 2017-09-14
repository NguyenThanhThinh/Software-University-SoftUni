using System;
using System.Text;
using System.Reflection;

public class Spy
{
    private StringBuilder sb;

    public Spy()
    {
        this.sb = new StringBuilder();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        this.sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
        this.sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in classMethods)
        {
            this.sb.AppendLine(method.Name);
        }
        return this.sb.ToString().Trim();
    }
}