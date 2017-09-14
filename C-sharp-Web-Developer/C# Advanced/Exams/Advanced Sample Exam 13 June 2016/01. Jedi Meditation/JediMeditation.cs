using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class JediMeditation
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        StringBuilder input = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            input.Append(Console.ReadLine() + " ");
        }

        var jedits = input.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        Queue<string> masters = new Queue<string>();
        Queue<string> knights = new Queue<string>();
        Queue<string> padawans = new Queue<string>();
        Queue<string> toshkoAndSlav = new Queue<string>();

        for (int i = 0; i < jedits.Length; i++)
        {
            if (jedits[i][0] == 'm')
            {
                masters.Enqueue(jedits[i]);
            }
            else if (jedits[i][0] == 'k')
            {
                knights.Enqueue(jedits[i]);
            }
            else if (jedits[i][0] == 'p')
            {
                padawans.Enqueue(jedits[i]);
            }
            else if (jedits[i][0] == 's' || jedits[i][0] == 't')
            {
                toshkoAndSlav.Enqueue(jedits[i]);
            }
        }

        if (jedits.Any(y => y[0].Equals('y')))
        {
            var test = masters.Concat(knights);
            test = test.Concat(toshkoAndSlav);
            test = test.Concat(padawans);
            Console.WriteLine(string.Join(" ", test));
        }
        else
        {
            var test = toshkoAndSlav.Concat(masters);
            test = test.Concat(knights);
            test = test.Concat(padawans);
            Console.WriteLine(string.Join(" ", test));
        }
    }
}