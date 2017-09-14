using System;
using System.Linq;

class DecimalToHex
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        string hexNum = "";
        long holder = 0;

        while (n != 0)
        {
            holder = n % 16;
            n /= 16;

            if (holder >= 0 && holder < 10)
            {
                hexNum += holder.ToString();
            }
            else
            {
                switch (holder)
                {
                    case 10:
                        hexNum += "A";
                        break;
                    case 11:
                        hexNum += "B";
                        break;
                    case 12:
                        hexNum += "C";
                        break;
                    case 13:
                        hexNum += "D";
                        break;
                    case 14:
                        hexNum += "E";
                        break;
                    case 15:
                        hexNum += "F";
                        break;

                    default:
                        break;
                }
            }
        }

        char[] reversedOutput = hexNum.Reverse().ToArray();

        foreach (char num in reversedOutput)
        {
            Console.Write(num);
        }
        Console.WriteLine();
    }
}