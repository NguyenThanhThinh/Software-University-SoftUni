using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CubicArtillery
{
    public static void Main()
    {
        int capacity = int.Parse(Console.ReadLine());
        Queue<string> bunkers = new Queue<string>();
        Queue<int> wepons = new Queue<int>();
        StringBuilder result = new StringBuilder();

        var input = Console.ReadLine().Split();

        while (!input[0].Equals("Bunker"))
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i][0]))
                {
                    bunkers.Enqueue(input[i]);
                }
                else
                {
                    int currentWepon = int.Parse(input[i]);
                    string currentBunker = string.Empty;
                    if (wepons.Sum() + currentWepon > capacity)
                    {
                        if (bunkers.Count > 1)
                        {
                            // ako bunkera nqma oryjiq napishi Empty
                            if (wepons.Count > 0)
                            {
                                currentBunker = bunkers.Dequeue();
                                PrintFullBunker(currentBunker, wepons, result);
                            }
                            if (currentWepon <= capacity)
                            {
                                wepons.Enqueue(currentWepon);
                            }
                            else
                            {
                                if (bunkers.Count > 1)
                                {
                                    result.AppendLine(bunkers.Dequeue() + " -> Empty");
                                }
                            }
                            break;
                        }
                        if (bunkers.Count == 1)
                        {
                            //proverka izobshto tova uryjie moje li da vleze
                            if (currentWepon <= capacity)
                            {
                                //proveri dali moje da se sybere i zapochni da praznish za da slojish oryjieto
                                while (wepons.Sum() + currentWepon > capacity)
                                {
                                    wepons.Dequeue();
                                }
                                wepons.Enqueue(currentWepon);
                                // ne trqbva da vadq bunkera ako e posleden
                                //currentBunker = bunkers.Peek();
                                //PrintFullBunker(currentBunker, wepons, result);
                            }
                        }
                    }
                    else
                    {
                        wepons.Enqueue(currentWepon);
                    }
                }
            }
            input = Console.ReadLine().Split();
        }
        Console.WriteLine(result);
    }

    private static void PrintFullBunker(string currentBunker, Queue<int> wepons, StringBuilder result)
    {
        result.Append(currentBunker + " -> ");
        result.AppendLine(string.Join(", ", wepons));
        wepons.Clear();
    }
}