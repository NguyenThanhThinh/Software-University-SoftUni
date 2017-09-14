using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Test
{
    static void Main()
    {
        //List<string> test = new List<string> { "Bankin", "Vinkel" };
        SortedSet<string> hash = new SortedSet<string> { "Stadion na mira", "Biad", "everywhere", "Letishteto", "Statue of Liberty" };
        Dictionary<string, string> test = new Dictionary<string, string>();

        test.Add("az", "ti");
        Console.WriteLine(test[0]);

    }
}
