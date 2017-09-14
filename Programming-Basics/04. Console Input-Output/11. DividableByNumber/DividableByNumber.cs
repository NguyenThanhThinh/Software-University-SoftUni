using System;

class DividableByNumber
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int p = 0;
        //string holder = "";
        //string holder2 = "";
        //string holder3 = "";

        for (int i = start; i <= end; i++)
        {
            if ((i % 5 == 0))
            {
                p++;
                //holder += i;
                //holder += ", ";
                Console.Write("{0} ", i);
            }
            /*if (i == end)
            {
                holder2 = holder.TrimEnd(' ');
                holder3 = holder2.TrimEnd(',');
            }*/
        }
        //Console.Write(holder3);
        Console.WriteLine(Environment.NewLine + p + Environment.NewLine);
    }
}