using System;

class HexToDecimal
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();
        long num = 0L;
        int numOrnot = 0;

        for (int i = 0; i < hexNumber.Length; i++)
        {
            bool isNumeric = int.TryParse(hexNumber[hexNumber.Length - 1 - i].ToString(), out numOrnot);
            if (isNumeric)
            {
                num += (long)(int.Parse(hexNumber[hexNumber.Length - 1 - i].ToString()) * Math.Pow(16, i));
            }
            switch (hexNumber[hexNumber.Length - 1 - i])
            {
                case 'A': num += (long)(10 * Math.Pow(16, i));
                    break;
                case 'B': num += (long)(11 * Math.Pow(16, i));
                    break;
                case 'C': num += (long)(12 * Math.Pow(16, i));
                    break;
                case 'D': num += (long)(13 * Math.Pow(16, i));
                    break;
                case 'E': num += (long)(14 * Math.Pow(16, i));
                    break;
                case 'F': num += (long)(15 * Math.Pow(16, i));
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine(num);
    }
}