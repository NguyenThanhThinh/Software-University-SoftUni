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

    public string StealFieldInfo(string className, params string[] fildsNames)
    {
        Type classType = Type.GetType(className, false);
        FieldInfo[] classTypeFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        Object classTypeInstance = Activator.CreateInstance(classType, new object[] { });

        this.sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in classTypeFields)
        {
            foreach (var fildName in fildsNames)
            {
                if (field.Name == fildName)
                {
                    this.sb.AppendLine($"{fildName} = {field.GetValue(classTypeInstance)}");
                }
            }
        }

        return this.sb.ToString().Trim();
    }
}