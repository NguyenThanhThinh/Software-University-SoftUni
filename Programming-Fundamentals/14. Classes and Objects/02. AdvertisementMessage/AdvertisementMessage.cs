using System;
using System.Collections.Generic;

class AdvertisementMessage
{
    static void Main()
    {
        string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };

        string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

        string[] author = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

        string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

        int numberOfMessages = int.Parse(Console.ReadLine());

        var randomNum = new Random();

        for (int i = 0; i < numberOfMessages; i++)
        {
            List<int> currentRandomNum = new List<int>();
            currentRandomNum.Add(randomNum.Next(0, phrases.Length));
            currentRandomNum.Add(randomNum.Next(0, events.Length));
            currentRandomNum.Add(randomNum.Next(0, author.Length));
            currentRandomNum.Add(randomNum.Next(0, cities.Length));

            Console.WriteLine("{0} {1} {2} - {3}", phrases[currentRandomNum[0]], events[currentRandomNum[1]], author[currentRandomNum[2]],
                cities[currentRandomNum[3]]);
        }
    }
}