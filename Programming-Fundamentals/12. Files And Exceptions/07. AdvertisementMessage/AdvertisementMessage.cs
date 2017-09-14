using System;
using System.Collections.Generic;
using System.IO;

class AdvertisementMessage
{
    static void Main()
    {
        string[] phrases = File.ReadAllLines(@"../../phrases.txt");

        string[] events = File.ReadAllLines(@"../../events.txt");

        string[] author = File.ReadAllLines(@"../../author.txt");

        string[] cities = File.ReadAllLines(@"../../cities.txt");

        int numberOfMessages = int.Parse(Console.ReadLine());

        var randomNum = new Random();

        for (int i = 0; i < numberOfMessages; i++)
        {
            List<int> currentRandomNum = new List<int>();
            currentRandomNum.Add(randomNum.Next(0, phrases.Length));
            currentRandomNum.Add(randomNum.Next(0, events.Length));
            currentRandomNum.Add(randomNum.Next(0, author.Length));
            currentRandomNum.Add(randomNum.Next(0, cities.Length));

            File.AppendAllText("../../output.txt", phrases[currentRandomNum[0]] + " " + events[currentRandomNum[1]] + " " + author[currentRandomNum[2]] +
                " " + cities[currentRandomNum[3]] + Environment.NewLine);
        }
    }
}