using System;
using System.Linq;
using System.Reflection;
using _01.Card_Suit;
using _03.Card_Power;

namespace _06.Custom_Enum_Attribute
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            if (input.Equals("Rank"))
            {
                var attributes = typeof(Rank).GetCustomAttributes();
                TypeAttribute typeAttribute = attributes.ToArray()[0] as TypeAttribute;
                Console.WriteLine($"Type = {typeAttribute.Type}, Description = {typeAttribute.Description}");
            }
            else
            {
                var attributes = typeof(Suit).GetCustomAttributes();
                TypeAttribute typeAttribute = attributes.ToArray()[0] as TypeAttribute;
                Console.WriteLine($"Type = {typeAttribute.Type}, Description = {typeAttribute.Description}");
            }
        }
    }
}