using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        decimal km = 150M;
        decimal speed = 100M;
        decimal time = km / speed;
        Console.WriteLine(time);
    }
}