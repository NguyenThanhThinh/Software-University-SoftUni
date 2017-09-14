using System;

namespace _08.CistomList
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                var splitInput = input.Split();
                CommandInterpreter.Command(splitInput);
                input = Console.ReadLine();
            }

            Console.WriteLine(CommandInterpreter.Result.ToString());
        }
    }
}