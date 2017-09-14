using System;
using System.Reflection;

public class OldestFamilyMember
{
    public static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }


        int numberOfPeople = int.Parse(Console.ReadLine());
        var family = new Family();

        for (int i = 0; i < numberOfPeople; i++)
        {
            var data = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None);
            family.AddMember(new Person
            {
                name = data[0],
                age = int.Parse(data[1])
            });  
        }

        Console.WriteLine();
        family.GetOldestMember();
    }
}