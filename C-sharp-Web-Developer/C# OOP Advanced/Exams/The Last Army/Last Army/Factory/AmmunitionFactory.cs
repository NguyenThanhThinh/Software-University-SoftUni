using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(ammunitionName));

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(type, new object[] { ammunitionName });
        return ammunition;
    }
}