using System;
using System.Linq;
using System.Text;

class HogwartsSorting
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int gryffindor = 0;
        int slytherin = 0;
        int ravenclaw = 0;
        int hufflepuff = 0;

        long sum = 0;
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            sum = CalculateCurrentSum(input);

            switch (sum % 4)
            {
                case 0:
                    gryffindor++;
                    result.AppendLine("Gryffindor " + sum + TakeFirstTwoInitials(input));
                    break;
                case 1:
                    slytherin++;
                    result.AppendLine("Slytherin " + sum + TakeFirstTwoInitials(input));
                    break;
                case 2:
                    ravenclaw++;
                    result.AppendLine("Ravenclaw " + sum + TakeFirstTwoInitials(input));
                    break;
                case 3:
                    hufflepuff++;
                    result.AppendLine("Hufflepuff " + sum + TakeFirstTwoInitials(input));
                    break;
                default:
                    break;
            }
        }

        result.AppendLine();
        result.AppendLine("Gryffindor: " + gryffindor);
        result.AppendLine("Slytherin: " + slytherin);
        result.AppendLine("Ravenclaw: " + ravenclaw);
        result.AppendLine("Hufflepuff: " + hufflepuff);
        Console.WriteLine(result.ToString());
    }

    private static string TakeFirstTwoInitials(string input)
    {
        string firstName = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)[0];
        string secondName = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

        return firstName[0].ToString() + secondName[0];
    }

    private static long CalculateCurrentSum(string input)
    {
        long sum = 0;
        var split = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < split.Count(); i++)
        {
            for (int p = 0; p < split[i].Length; p++)
            {
                sum += (int)split[i][p];
            }
        }
        return sum;
    }
}