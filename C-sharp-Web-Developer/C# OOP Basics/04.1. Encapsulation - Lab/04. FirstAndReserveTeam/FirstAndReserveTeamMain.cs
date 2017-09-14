using System;

public class FirstAndReserveTeamMain
{
    public static void Main()
    {
        var lines = int.Parse(Console.ReadLine());
        Team team = new Team("Sevi");

        for (int i = 0; i < lines; i++)
        {
            try
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    double.Parse(cmdArgs[3]));

                team.AddPlayer(person);
            }
            catch (ArgumentException arg)
            {
                Console.WriteLine(arg.Message);
            }
        }
        Console.WriteLine(team.ToString());
    }
}