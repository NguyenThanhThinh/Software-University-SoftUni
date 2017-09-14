using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


class DrawFort
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int w = n * 2;
        int h = n;
        int y = n / 2;
        int z = w - (y * 2) - 4;
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < 1; i++)
        {
            result.Append("/");
            for (int j = 0; j < y; j++)
            {
                result.Append("^");
            }
            result.Append("\\");
            for (int k = 0; k < z; k++)
            {
                result.Append("_");
            }
            result.Append("/");
            for (int j = 0; j < y; j++)
            {
                result.Append("^");
            }
            result.Append("\\");
            result.AppendLine();
        }

        if (h <= 4)
        {
            for (int i = 0; i < h - 2; i++)
            {
                result.Append("|");
                result.Append(new string(' ', w - 2));
                result.Append("|");
                result.AppendLine();
            } 
        }

        if (h > 4)
        {
            for (int i = 0; i < h - 3; i++)
            {
                result.Append("|");
                result.Append(new string(' ', w - 2));
                result.Append("|");
                result.AppendLine();
            }

            result.Append("|");
            result.Append(new string(' ', y+1));
            result.Append(new string('_', z));
            result.Append(new string(' ', y+1));
            result.Append("|");
            result.AppendLine();
        }

        result.Append("\\");
        result.Append(new string('_', y));
        result.Append("/");
        result.Append(new string(' ', z));
        result.Append("\\");
        result.Append(new string('_', y));
        result.Append("/");

        Console.WriteLine(result);
    }
}
