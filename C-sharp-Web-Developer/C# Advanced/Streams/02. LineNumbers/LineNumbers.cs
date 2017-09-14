using System.IO;

public class LineNumbers
{
    public static void Main()
    {
        StreamReader read = new StreamReader(@"../../data.txt");
        StreamWriter write = new StreamWriter(@"../../newdata.txt");
        int index = 0;

        using (read)
        {
            using (write)
            {
                string line = read.ReadLine();

                while (line != null)
                {
                    write.WriteLine($"{index}. {line}");
                    line = read.ReadLine();
                    index++;
                }
            }
        }
    }
}