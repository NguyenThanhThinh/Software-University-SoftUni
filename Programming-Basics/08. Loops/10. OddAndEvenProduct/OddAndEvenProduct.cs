using System;
using System.Linq;

class OddAndEvenProduct
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int oddProduct = 1;
        int evenProduct = 1;

        for (int i = 0, x = 1; i < numbers.Length; i += 2, x += 2)
        {
            oddProduct *= numbers[i];
            if (x < numbers.Length)
            {
                evenProduct *= numbers[x];
            }
        }

        if (oddProduct == evenProduct)
        {
            Console.WriteLine("Yes\nProduct = {0}", oddProduct);
        }
        else
        {
            Console.WriteLine("no\nodd_product = {0}\neven_product = {1}", oddProduct, evenProduct);
        }
    }
}