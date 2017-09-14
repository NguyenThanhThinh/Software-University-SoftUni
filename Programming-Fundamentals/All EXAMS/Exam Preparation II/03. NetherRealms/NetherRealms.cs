using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.NetherRealms
{
    class NetherRealms
    {
        static void Main()
        {
            List<Demon> demons = new List<Demon>();
            var input = Console.ReadLine().Split(new char[] { ',', ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string name = input[i];
                demons.Add(new Demon());
                demons[i].Name = name;
                long health = 0;
                double damage = 0d;

                Regex regex = new Regex(@"[^0-9+\-*\/\.]");
                MatchCollection match = regex.Matches(input[i]);

                if (match.Count > 0)
                {
                    foreach (Match item in match)
                    {
                        string currentItem = item.Value;
                        foreach (char c in currentItem)
                        {
                            health += (int)c;
                        }
                    }
                }
                demons[i].Health = health;
                //regex = new Regex(@"(\-?[0-9]+\.?[0-9]+)|(\-?[0-9](?!\.))");
                regex = new Regex(@"[+-]?\d+(?:\.?\d+)?");
                match = regex.Matches(input[i]);
                double[] numbers = GetNumbersForDamage(match);

                regex = new Regex(@"[\*\/]");
                match = regex.Matches(input[i]);
                damage = CalculateDamage(numbers, match);
                demons[i].Damage = damage;
            }

            foreach (Demon demon in demons.OrderBy(n => n.Name))
            {
                Console.WriteLine("{0} - {1} health, {2:F2} damage", demon.Name, demon.Health, demon.Damage);
            }
        }

        private static double CalculateDamage(double[] numbers, MatchCollection match)
        {
            double damage = 0d;

            for (int i = 0; i < numbers.Length; i++)
            {
                damage += numbers[i];
            }
            if (match.Count > 0)
            {
                foreach (Match item in match)
                {
                    if (item.Value == "*")
                    {
                        damage *= 2;
                    }
                    else if (item.Value == "/")
                    {
                        damage /= 2;
                    }
                }
                return damage;
            }
            else
            {
                return damage;
            }
        }

        private static double[] GetNumbersForDamage(MatchCollection match)
        {
            double[] numbers = new double[match.Count];
            int i = 0;
            foreach (Match item in match)
            {
                numbers[i] = double.Parse(item.Value);
                i++;
            }
            return numbers;
        }
    }

    class Demon
    {
        public string Name { get; set; }
        public long Health { get; set; }
        public double Damage { get; set; }
    }
}
