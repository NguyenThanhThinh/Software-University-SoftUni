using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class Startup
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var list = command.Split().ToList();
            list.RemoveAt(0);
            ListyIterator<string> listy = new ListyIterator<string>(list);

            while (!command.Equals("END"))
            {
                try
                {
                    switch (command)
                    {
                        case "Print":
                            listy.Print();
                            break;
                        case "Move":
                            Console.WriteLine(listy.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listy.HasNext());
                            break;
                    }
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }
                command = Console.ReadLine();
            }
        }
    }
}