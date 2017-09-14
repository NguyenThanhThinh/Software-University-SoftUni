using System;
using System.Collections.Generic;

namespace _03.Stack
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<int>();

            while (!input[0].Equals("END"))
            {
                string command = input[0];

                try
                {
                    switch (command)
                    {
                        case "Push":
                            var numbers = GetNumbers(input);
                            foreach (var number in numbers)
                            {
                                stack.Push(number);
                            }
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                    }
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }

                input = Console.ReadLine().Split();
            }

            ForEachCollection(stack);
            ForEachCollection(stack);
        }

        private static void ForEachCollection(Stack<int> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        private static List<int> GetNumbers(string[] input)
        {
            var numbers = new List<int>();

            for (int i = 1; i < input.Length; i++)
            {
                numbers.Add(int.Parse(input[i]));
            }

            return numbers;
        }
    }
}