using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name.Equals(difficultyLevel));

        object[] objectsParams = new object[] { neededPoints };
        IMission mission = (IMission)Activator.CreateInstance(type, objectsParams);
        return mission;
    }
}