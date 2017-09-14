using System;
using System.Text;

class DressPattern
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        char dot = '.';
        char dash = '_';
        char star = '*';
        char letter = 'o';

        StringBuilder dress = new StringBuilder();
        int width = (12 * n) + 2;
        int m = (width - 2) / 3;
        dress.AppendLine(new string(dash, m) + dot + new string(dash, m) + dot + new string(dash, m));

        dress = DrawFirstPart(n, width, dress, dash, dot, star);
        dress = DrawSecondPart(n, width, dot, star, dress);
        dress = DrawThirdPart(n, letter, star, dot, dash, width, dress);
        dress = DrawForthPart(n, dash, dot, star, width, dress);
        dress.AppendLine(new string(dot, width));

        Console.WriteLine(dress.ToString());
    }

    private static StringBuilder DrawForthPart(int n, char dash, char dot, char star, int width, StringBuilder dress)
    {
        int dashCount = 3 * n;
        int starCount = width - ((dashCount * 2) + 2);

        for (int i = 0; i < 3 * n; i++)
        {
            dress.AppendLine(new string (dash, dashCount) + dot + new string(star, starCount) + dot + new string(dash, dashCount));
            //Console.WriteLine(dress.ToString());
            dashCount--;
            starCount = width - ((dashCount * 2) + 2);
        }
        return dress;
    }

    private static StringBuilder DrawThirdPart(int n, char letter, char star, char dot, char dash, int width, StringBuilder dress)
    {
        int middle = width - ((3 * n) * 2);

        for (int i = 0; i < n + 1; i++)
        {
            if (i == 0)
            {
                dress.AppendLine(new string(dot, 3 * n) + new string(star, middle) + new string(dot, 3 * n));
            }
            else
            {
                dress.AppendLine(new string(dash, 3 * n) + new string(letter, middle) + new string(dash, 3 * n));
            }
        }
        return dress;
    }

    private static StringBuilder DrawSecondPart(int n, int width, char dot, char star, StringBuilder dress)
    {
        for (int i = 0; i < n; i++)
        {
            dress.AppendLine(dot + new string(star, width - 2) + dot);
        }
        return dress;
    }

    private static StringBuilder DrawFirstPart(int n, int width, StringBuilder dress, char dash, char dot, char star)
    {
        int c = 2;
        int m = (width - (c * 2 + 4)) / 3;

        for (int i = 0; i < 2 * n; i++)
        {
            dress.AppendLine(new string(dash, m) + dot + new string(star, c) + dot + new string(dash, m) + dot + new string(star, c) + dot + new string(dash, m));
            //Console.WriteLine(dress);
            c += 3;
            m = (width - (c * 2 + 4)) / 3;
        }
        return dress;
    }
}