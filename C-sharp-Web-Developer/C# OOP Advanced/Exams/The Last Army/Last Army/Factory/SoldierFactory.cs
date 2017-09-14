using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        object[] paramsObjects = new object[] { name, age, experience, endurance };

        Type unitType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(soldierTypeName));

        ISoldier unit = (ISoldier)Activator.CreateInstance(unitType, paramsObjects);

        return unit;
    }
}