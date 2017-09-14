using System;
using System.Collections.Generic;
using _05.BorderControl;

namespace _06.BirthdayCelebrations
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            List<IInformatanable> species = new List<IInformatanable>();

            while (!input[0].Equals("End"))
            {
                if (input[0].Equals("Pet"))
                {
                    string name = input[1];
                    string birthdayDate = input[2];
                    species.Add(new Pet(name, birthdayDate));
                }
                else if (input.Length == 5)
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdayDate = input[4];
                    species.Add(new Citizen(name, age, id, birthdayDate));
                }

                input = Console.ReadLine().Split();
            }

            var birthday = Console.ReadLine();
            species.ForEach(s => s.GetBirthdayIfMatch(birthday));
        }
    }
}