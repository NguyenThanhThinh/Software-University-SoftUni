using System;

class NumberInWords
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int number = int.Parse(input);

        string[] numberUnits = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve",
                                "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] numberTenths = { "", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
        string hundred = "hundred";

        if (number >= 0 && number <= 19)
        {
            Console.WriteLine(numberUnits[number]);
        }

        else if (number >= 20 && number <= 99)
        {
            if (input[1] != '0')
            {
                Console.WriteLine(numberTenths[int.Parse(input[0].ToString())] + " " + numberUnits[int.Parse(input[1].ToString())]);
            }
            else
            {
                Console.WriteLine(numberTenths[int.Parse(input[0].ToString())]);
            }
        }

        else
        {
            int lastTwoDigits = 0;
            string lastTwoStrings = "";
            if (input[0] == '1')
            {
                if (input[1] == '1')
                {
                    lastTwoStrings += input[1];
                    lastTwoStrings += input[2];
                    lastTwoDigits = int.Parse(lastTwoStrings);
                    Console.WriteLine("One {0} and {1}", hundred, numberUnits[lastTwoDigits]);
                }
                else if (input[1] == '0' && input[2] != '0')
                {
                    Console.WriteLine("One {0} and {1}", hundred, numberUnits[int.Parse(input[2].ToString())]);
                }
                else if (input[1] != '0' && input[2] != '0')
                {
                    Console.WriteLine("One {0} and {1} {2}", hundred, numberTenths[int.Parse(input[1].ToString())],
                                                             numberUnits[int.Parse(input[2].ToString())]);
                }
                else if (input[1] != '0' && input [2] == '0')
                {
                    Console.WriteLine("One {0} and {1}", hundred, numberTenths[int.Parse(input[1].ToString())]);
                }
                else
                {
                    Console.WriteLine("One {0}", hundred);
                }
            }

            else
            {
                if (input[1] == '1')
                {
                    lastTwoStrings += input[1];
                    lastTwoStrings += input[2];
                    lastTwoDigits = int.Parse(lastTwoStrings);
                    Console.WriteLine("{0} {1} and {2}", numberUnits[int.Parse(input[0].ToString())], hundred, numberUnits[lastTwoDigits]);
                }
                else if (input[1] != '1' && input[2] == '0')
                {
                    Console.WriteLine("{0} {1} and {2}", numberUnits[int.Parse(input[0].ToString())], hundred, 
                                                        numberTenths[int.Parse(input[1].ToString())]);
                }
                else
                {
                    Console.WriteLine("{0} {1} and {2} {3}", numberUnits[int.Parse(input[0].ToString())], hundred, 
                                                            numberTenths[int.Parse(input[1].ToString())], numberUnits[int.Parse(input[2].ToString())]);
                }
            }
        }
    }
}