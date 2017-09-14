using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TransportPrice
{
    static void Main()
    {
        int km = int.Parse(Console.ReadLine());
        string day = Console.ReadLine();

        decimal taxiPrice = 0M;
        decimal busPrice = 0M;
        decimal trainPrice = 0M;
        

        if (true)
        {
            if (day == "day")
            {
                taxiPrice = 0.70m + (km * 0.79m);
            }
            else
            {
                taxiPrice = 0.70m + (km * 0.90M);
            }
        }

        if (km >= 20)
        {
            busPrice = km * 0.09M;
        }

        if (km >= 100)
        {
            trainPrice = km * 0.06M;
        }

        if (km < 20)
        {
            Console.WriteLine(taxiPrice);
        }
        else if (km >= 20 && km < 100)
        {
            if (taxiPrice > busPrice)
            {
                Console.WriteLine(busPrice);
            }
            else
            {
                Console.WriteLine(taxiPrice);
            }
        }
        else
        {
            if (taxiPrice < busPrice)
            {
                if (taxiPrice < trainPrice)
                {
                    Console.WriteLine(taxiPrice);
                }
            }
            else if (busPrice < taxiPrice)
            {
                if (busPrice < trainPrice)
                {
                    Console.WriteLine(busPrice);
                }
                else
                {
                    Console.WriteLine(trainPrice);
                }
            }
            

        }

    }
}
