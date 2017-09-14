using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05.BorderControl;

namespace _07.FoodShortage
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthday = input[3];

                    buyers.Add(new Citizen(name, age, id, birthday));
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    buyers.Add(new Rebel(name, age, group));
                }
            }

            string nameInput = Console.ReadLine();

            while (!nameInput.Equals("End"))
            {
                if (buyers.Any(b => b.Name.Equals(nameInput)))
                {
                    int id = buyers.FindIndex(b => b.Name.Equals(nameInput));
                    buyers[id].BuyFood();
                }
                nameInput = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}