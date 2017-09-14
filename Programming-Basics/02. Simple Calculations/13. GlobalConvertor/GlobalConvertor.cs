using System;

class GlobalConvertor
{
    static void Main()
    {
        double usdValue = 1.79549;
        double eurValue = 1.95583;
        double gbpValue = 2.53405;

        double amount = Double.Parse(Console.ReadLine());
        string currencyOne = Console.ReadLine();
        string currencyTwo = Console.ReadLine();

        

        if (currencyOne == "BGN" && currencyTwo == "USD")
        {
            double result = amount / usdValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }

        else if (currencyOne == "BGN" && currencyTwo == "EUR")
        {
            double result = amount / eurValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }

        else if (currencyOne == "BGN" && currencyTwo == "GBP")
        {
            double result = amount / gbpValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }

        else if (currencyOne == "USD" && currencyTwo == "BGN")
        {
            double result = amount * usdValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }
        else if (currencyOne == "USD" && currencyTwo == "EUR")
        {
            double result = amount * usdValue / eurValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }
        else if (currencyOne == "USD" && currencyTwo == "GBP")
        {
            double result = amount * usdValue / gbpValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }

        else if (currencyOne == "EUR" && currencyTwo == "BGN")
        {
            double result = amount * eurValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }
        else if (currencyOne == "EUR" && currencyTwo == "USD")
        {
            double result = amount * eurValue / usdValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }
        else if (currencyOne == "EUR" && currencyTwo == "GBP")
        {
            double result = (amount * eurValue) / gbpValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }

        else if (currencyOne == "GBP" && currencyTwo == "BGN")
        {
            double result = amount * gbpValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }
        else if (currencyOne == "GBP" && currencyTwo == "USD")
        {
            double result = amount * gbpValue / usdValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }
        else if(currencyOne == "GBP" && currencyTwo == "EUR")
        {
            double result = amount * gbpValue / eurValue;
            Console.WriteLine("{0} {1}", Math.Round(result, 2), currencyTwo);
        }
    }
}

