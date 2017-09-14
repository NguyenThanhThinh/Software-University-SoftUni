using System;

namespace _03.Ferrari
{
    public class Startup
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

            ICar car = new Ferrari(name);
            Console.WriteLine(car.ToString());
        }
    }
}