using System;
using System.Linq;
using System.Text;
using System.Reflection;

public class Spy
{
    private StringBuilder sb;

    public Spy()
    {
        this.sb = new StringBuilder();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classGetMethods =
            classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in classGetMethods.Where(m => m.Name.StartsWith("get")))
        {
            this.sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in classGetMethods.Where(m => m.Name.StartsWith("set")))
        {
            this.sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return this.sb.ToString().Trim();
    }
}