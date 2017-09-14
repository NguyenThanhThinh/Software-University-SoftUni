using System;
using System.Text;

class Strawberry
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        char leftLeaf = '\\';
        char middleLeaf = '|';
        char rightLeaf = '/';
        char outline = '#';
        char inside = '.';
        char dash = '-';

        StringBuilder strawberry = new StringBuilder();

        int d = (n * 2) + 3;

        strawberry = FirstPart(leftLeaf, middleLeaf, rightLeaf, dash, n);
        strawberry.AppendLine(new string(dash, n) + outline + inside + outline + new string(dash, n));
        strawberry = ThirdPart(outline, inside, dash, d, strawberry);
        strawberry = ForthPart(outline, inside, dash, d, strawberry, n);

        Console.WriteLine(strawberry.ToString());
    }

    private static StringBuilder ForthPart(char outline, char inside, char dash, int d, StringBuilder strawberry, int n)
    {
        int insideCounter = d - 2;
        int dashCounter = 0;

        for (int i = insideCounter; i >= 1 ; i -= 2)
        {
            strawberry.Append(new string(dash, dashCounter));
            strawberry.Append(outline);
            strawberry.Append(new string(inside, i));
            strawberry.Append(outline);
            strawberry.AppendLine(new string(dash, dashCounter));

            dashCounter++;
        }
        return strawberry;
    }

    private static StringBuilder ThirdPart(char outlines, char inside, char dash, int d, StringBuilder strawberry)
    {
        int dashCount = (d - 7) / 2;

        for (int i = 5; i <= d - 2; i += 4)
        {
            strawberry.Append(new string(dash, dashCount));
            strawberry.Append(outlines);
            strawberry.Append(new string(inside, i));
            strawberry.Append(outlines);
            strawberry.AppendLine(new string(dash, dashCount));

            dashCount -= 2;
        }
        return strawberry;
    }

    private static StringBuilder FirstPart(char leftLeaf, char middleLeaf, char rightLeaf, char dash, int n)
    {
        StringBuilder strawberry = new StringBuilder();
        int dashCount = 0;

        for (int i = n; i >= 3; i -= 2)
        {
            strawberry.Append(new string (dash, dashCount));
            strawberry.Append(leftLeaf);
            strawberry.Append(new string(dash, i));
            strawberry.Append(middleLeaf);
            strawberry.Append(new string(dash, i));
            strawberry.Append(rightLeaf);
            strawberry.AppendLine(new string(dash, dashCount));

            dashCount += 2;
        }
        return strawberry;
    }
}