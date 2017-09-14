using System;
using System.IO;

public class OddLines
{
    public static void Main()
    {
        StreamReader read = new StreamReader("../../data.txt");
        int index = 0;
        var input = read.ReadLine();

        using (read)
        {
            while (input != null)
            {
                if (index % 2 != 0)
                {
                    Console.WriteLine(input);
                }
                index++;
                input = read.ReadLine();
            }
        }
    }
}