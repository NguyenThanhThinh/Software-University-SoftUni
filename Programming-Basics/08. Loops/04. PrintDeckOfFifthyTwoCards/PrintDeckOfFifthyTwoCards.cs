using System;

class PrintDeckOfFifthyTwoCards
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        char[] colors = { '\u2660', '\u2663', '\u2666', '\u2665' };
        string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        for (int i = 0; i < cards.Length; i++)
        {
            for (int p = 0; p < colors.Length; p++)
            {
                Console.Write("{0}{1} ", cards[i], colors[p]);
            }
            Console.WriteLine();
        }
    }
}