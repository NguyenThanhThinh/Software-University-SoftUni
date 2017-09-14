using System;
using System.Linq;

class NumberCalculation
{
    static void Main()
    {
        Console.Write("Choose with what set you want to work (int, double or decimal): ");
        string type = Console.ReadLine();

        if (type == "int")
        {
            Console.Write("Now type the numbers [x, x, x ...]: ");
            int[] numbers = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.Write("Sum: ");
            Sum(numbers);
            Console.Write("MinValue: ");
            MinValue(numbers);
            Console.Write("MaxValue: ");
            MaxValue(numbers);
            Console.Write("Avarage: ");
            Avarage(numbers);
            Console.Write("Product: ");
            Product(numbers);

        }
        else if (type == "double")
        {
            Console.Write("Now type the numbers [x, x, x ...]: ");
            double[] numbers = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Console.Write("Sum: ");
            Sum(numbers);
            Console.Write("MinValue: ");
            MinValue(numbers);
            Console.Write("MaxValue: ");
            MaxValue(numbers);
            Console.Write("Avarage: ");
            Avarage(numbers);
            Console.Write("Product: ");
            Product(numbers);
        }
        else if (type == "decimal")
        {
            Console.Write("Now type the numbers [x, x, x ...]: ");
            decimal[] numbers = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            Console.Write("Sum: ");
            Sum(numbers);
            Console.Write("MinValue: ");
            MinValue(numbers);
            Console.Write("MaxValue: ");
            MaxValue(numbers);
            Console.Write("Avarage: ");
            Avarage(numbers);
            Console.Write("Product: ");
            Product(numbers);
        }
        else
        {
            Console.WriteLine("Invalid Entry");
        }
        
    }

    private static void MaxValue(int[] numbers)
    {
        int max = int.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (max < (int)numbers[i])
            {
                max = (int)numbers[i];
            }
        }
        Console.WriteLine(max);
    }

    private static void MaxValue(double[] numbers)
    {
        double max = double.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }
        Console.WriteLine(max);
    }

    private static void MaxValue(decimal[] numbers)
    {
        decimal max = decimal.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }
        Console.WriteLine(max);
    }

    private static void MinValue(int[] numbers)
    {
        int min = int.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (min > (int)numbers[i])
            {
                min = (int)numbers[i];
            }
        }
        Console.WriteLine(min);
    }

    private static void MinValue(double[] numbers)
    {
        double min = double.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (min > numbers[i])
            {
                min = numbers[i];
            }
        }
        Console.WriteLine(min);
    }

    private static void MinValue(decimal[] numbers)
    {
        decimal min = decimal.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (min > numbers[i])
            {
                min = numbers[i];
            }
        }
        Console.WriteLine(min);
    }

    private static void Sum(int[] numbers)
    {
        long sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += (long)numbers[i];
        }
        Console.WriteLine(sum);
    }

    private static void Sum(double[] numbers)
    {
        long sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += (long)numbers[i];
        }
        Console.WriteLine(sum);
    }

    private static void Sum(decimal[] numbers)
    {
        long sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += (long)numbers[i];
        }
        Console.WriteLine(sum);
    }

    private static void Avarage(int[] numbers)
    {
        int avarage = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            avarage += numbers[i];
        }
        avarage /= numbers.Length;
        Console.WriteLine(avarage);
    }

    private static void Avarage(double[] numbers)
    {
        double avarage = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            avarage += numbers[i];
        }
        avarage /= numbers.Length;
        Console.WriteLine(avarage);
    }

    private static void Avarage(decimal[] numbers)
    {
        decimal avarage = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            avarage += numbers[i];
        }
        avarage /= numbers.Length;
        Console.WriteLine(avarage);
    }

    private static void Product(int[] numbers)
    {
        long product = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        Console.WriteLine(product);
    }

    private static void Product(double[] numbers)
    {
        double product = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        Console.WriteLine(product);
    }

    private static void Product(decimal[] numbers)
    {
        decimal product = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        Console.WriteLine(product);
    }
}