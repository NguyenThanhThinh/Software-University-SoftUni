using System;
using System.Text;

namespace _09.Traffic_Lights
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            int cycleTimes = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 1; i <= cycleTimes; i++)
            {
                foreach (var item in input)
                {
                    var index = (int)Enum.Parse(typeof(Lights), item);
                    index = ReturnNextIndex(index, i);
                    sb.Append($"{(Lights)index} ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }

        public static int ReturnNextIndex(int currentIndex, int cycleIndex)
        {
            if (currentIndex + cycleIndex > 2)
            {
                return (currentIndex + cycleIndex) % 3;
            }
            return currentIndex + cycleIndex;
        }
    }
}