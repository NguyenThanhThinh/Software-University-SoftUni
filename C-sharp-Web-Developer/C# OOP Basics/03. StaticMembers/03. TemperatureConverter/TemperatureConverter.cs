using System;

public class TemperatureConverter
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();

        while (!input[0].Equals("End"))
        {
            int value = int.Parse(input[0]);
            if (input[1].Equals("Fahrenheit"))
            {
                Console.WriteLine("{0:F2} Celsius", ConvertTemperatureToCelsius(value));
            }
            else if (input[1].Equals("Celsius"))
            {
                Console.WriteLine("{0:F2} Fahrenheit", ConvertTemperatureToFahrenheit(value));
            }

            input = Console.ReadLine().Split();
        }
    }

    private static decimal ConvertTemperatureToFahrenheit(int number)
    {
        //T(°F) = T(°C) × 1.8 + 32
        decimal converted = (number * 1.8M) + 32;
        return converted;
    }

    private static decimal ConvertTemperatureToCelsius(int number)
    {
        //T(°C) = (T(°F) - 32) / 1.8
        decimal converted = (number - 32) / 1.8M;
        return converted;
    }
}