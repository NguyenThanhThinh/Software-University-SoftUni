using System;
using System.Collections.Generic;

namespace _10.Explicit_Interfaces
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            List<Citizen> people = new List<Citizen>();

            while (!input.Equals("End"))
            {
                var splitInput = input.Split();
                string name = splitInput[0];
                string country = splitInput[1];
                int age = int.Parse(splitInput[2]);

                people.Add(new Citizen(name, country, age));
                input = Console.ReadLine();
            }

            foreach (var citizen in people)
            {
                citizen.GetName();
                ((IResident)citizen).GetName();
            }
        }
    }
}