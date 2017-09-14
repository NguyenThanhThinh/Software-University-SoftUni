using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StupidPasswordGenerator
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int l = int.Parse(Console.ReadLine());
        StringBuilder password = new StringBuilder();
        int number = 97;
        int numberTwo = 97;
        int digit = 0;

        for (int i = 1; i < n; i++)
        {
            //if (stop == true)
            //{
            //    stop = false;
            //}
            password.Append(i);
            for (int j = 1; j < n; j++)
            {

                password.Append(j);
                number = 97;
                for (int k = 1; k <= l; k++)
                {

                    password.Append((char)number);
                    number++;
                    for (int m = 1; m <= l; m++)
                    {

                        password.Append((char)numberTwo);
                        numberTwo++;
                        if (i > j || i == j)
                        {
                            digit = i;
                        }
                        else
                        {
                            digit = j;
                        }
                        for (int o = digit + 1; o <= n; o++)
                        {
                            password.Append(o);
                            Console.Write(password + " ");
                            password.Remove(password.Length - 1, 1);

                        }
                        password.Remove(password.Length - 1, 1);
                    }
                    password.Remove(password.Length - 1, 1);
                    numberTwo = 97;
                }
                password.Remove(password.Length - 1, 1);
            }
            password.Remove(password.Length - 1, 1);
        }
        Console.WriteLine();
    }
}
