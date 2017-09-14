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

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] classTypeFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        MethodInfo[] classTypePrivateMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        MethodInfo[] classTypePublicMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (FieldInfo field in classTypeFields)
        {
            if (field.IsPublic)
            {
                this.sb.AppendLine($"{field.Name} must be private!");
            }
        }

        foreach (MethodInfo property in classTypePrivateMethods.Where(m => m.Name.StartsWith("get")))
        {
            this.sb.AppendLine($"{property.Name} have to be public!");
        }

        foreach (MethodInfo property in classTypePublicMethods.Where(m => m.Name.StartsWith("set")))
        {

            this.sb.AppendLine($"{property.Name} have to be private!");
        }

        return this.sb.ToString().Trim();
    }
}