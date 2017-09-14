using System;

class ASCII_Table
{
    static void Main()
    {
        int ascii = 0;
       
        for (int i = 0; i < 256; i++)
        {
            ascii++;
            char changeChar = Convert.ToChar(ascii);
            Console.WriteLine(changeChar);
        }
    }
}
