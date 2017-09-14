using System;

class SumSeconds
{
    static void Main(string[] args)
    {
        int firstValue = int.Parse(Console.ReadLine());
        int secondValue = int.Parse(Console.ReadLine());
        int thirdValue = int.Parse(Console.ReadLine());

        int total = firstValue + secondValue + thirdValue;

        int min = total / 60;
        int sec = total % 60;

        if (sec < 10)
        {
            Console.WriteLine("{0}:0{1}", min, sec);
        }
        else
        {
            Console.WriteLine("{0}:{1}", min, sec);
        }     
    }
}