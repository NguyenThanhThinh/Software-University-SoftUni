using System;

class ConvertValues
{
    static void Main(string[] args)
    {
        double number = double.Parse(Console.ReadLine());
        string firstValue = Console.ReadLine();
        string secondValue = Console.ReadLine();
        double result = 0d;

        if (firstValue == "m")
        {
            if (secondValue == "mm")
            {
                result = number * 1000;
            }
            else if (secondValue == "cm")
            {
                result = number * 100;
            }
            else if (secondValue == "mi")
            {
                result = number * 0.000621371192;
            }
            else if (secondValue == "in")
            {
                result = number * 39.3700787;
            }
            else if (secondValue == "km")
            {
                result = number * 0.001;
            }
            else if (secondValue == "ft")
            {
                result = number * 3.2808399;
            }
            else if (secondValue == "yd")
            {
                result = number * 1.0936133;
            }

        }

        else if (firstValue == "mm")
        {
            if (secondValue == "m")
            {
                result = number / 1000;
            }
            else if (secondValue == "cm")
            {
                result = number / 10;
            }
            else if (secondValue == "mi")
            {
                result = number * 0.000621371192;
            }
            else if (secondValue == "in")
            {
                result = number * 39.3700787;
            }
            else if (secondValue == "km")
            {
                result = number * 0.001;
            }
            else if (secondValue == "ft")
            {
                result = number * 3.2808399;
            }
            else if (secondValue == "yd")
            {
                result = number * 1.0936133;
            }

        }
        Console.WriteLine(result);
    }
}