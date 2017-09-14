using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Test
{
    static void Main(string[] args)
    {
        string test = "";

        for (int i = 0; i < 10; i++)
        {
            test += string.Join(", ", i);
        }
        Console.WriteLine(test);
    }
}
