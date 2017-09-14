using System;

class TheathePhotographer
{
    static void Main(string[] args)
    {
        double totalPictures = double.Parse(Console.ReadLine());
        double filterTime = double.Parse(Console.ReadLine());
        double goodPictures = double.Parse(Console.ReadLine());
        double timeForUpload = double.Parse(Console.ReadLine());

        double usefulPictures = 0d;
        usefulPictures = Math.Ceiling((goodPictures / 100) * totalPictures);
        double result = (totalPictures * filterTime) + (usefulPictures * timeForUpload);

        TimeSpan time = TimeSpan.FromSeconds(result);
        string str = time.ToString(@"d\:hh\:mm\:ss");
        Console.WriteLine(str);
    }
}