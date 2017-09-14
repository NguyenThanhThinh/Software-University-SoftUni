using System;
using System.Collections.Generic;

namespace _05.BorderControl
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            List<ICountable> species = new List<ICountable>();
            
            while (!input[0].Equals("End"))
            {
                if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];
                    species.Add(new Robot(id, model));
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    species.Add(new Citizen(name, age, id));
                }

                input = Console.ReadLine().Split();
            }

            var fakeId = Console.ReadLine();
            species.ForEach(s => s.FakeID(fakeId));
        }
    }
}