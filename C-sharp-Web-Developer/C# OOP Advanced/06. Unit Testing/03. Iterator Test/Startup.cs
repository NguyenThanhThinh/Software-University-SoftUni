using System;
using System.Linq;

namespace _03.Iterator_Test
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Skip(1).ToList();
            var command = Console.ReadLine();
            ListIterator list = new ListIterator(input);

            while (!command.Equals("END"))
            {
                switch (command)
                {
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (ArgumentException argNull)
                        {
                            Console.WriteLine(argNull.Message);
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}