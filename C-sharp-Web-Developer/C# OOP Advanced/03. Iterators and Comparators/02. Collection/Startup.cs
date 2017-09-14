using System;
using System.Linq;
using System.Text;
using _01.ListyIterator;

namespace _02.Collection
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
                        case "PrintAll":
                            var sb = new StringBuilder();
                            foreach (var item in listy)
                            {
                                sb.Append($"{item} ");
                            }
                            sb.Remove(sb.Length - 1, 1);
                            Console.WriteLine(sb);
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