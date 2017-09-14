using System;

class Torrent_Pirate
{
    static void Main()
    {
        decimal data = int.Parse(Console.ReadLine());
        decimal price = decimal.Parse(Console.ReadLine());
        decimal wifeSpending = decimal.Parse(Console.ReadLine());

        decimal oneMovie = 1500M;
        decimal number_of_movies = 0M;
        decimal mallPrice = 0M;
        decimal cinemaPrice = 0M;

        mallPrice = (((data / 2) / 60) / 60);
        mallPrice *= wifeSpending;

        number_of_movies = data / oneMovie;

        cinemaPrice = number_of_movies * price;

        if ((mallPrice == cinemaPrice) || (mallPrice < cinemaPrice))
        {
            Console.WriteLine("mall -> {0:F2}lv", mallPrice);
        }
        else
        {
            Console.WriteLine("cinema -> {0:F2}lv", cinemaPrice);
        }

    }
}
