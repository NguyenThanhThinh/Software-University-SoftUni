using System;
using System.Collections.Generic;
using System.Linq;

public static class PartyReservationFilterModule
{
    public static void Main()
    {
        var people = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var filtiredPeople = new List<string>(people);
        string input = Console.ReadLine();

        while (input != "Print")
        {
            var splitInput = input.Split();
            string command = splitInput[0];
            string type = splitInput[1].Substring(splitInput[1].IndexOf(';') + 1);

            if (type.Equals("Starts") || type.Equals("Ends"))
            {
                string param = string.Empty;
                param = splitInput[2].Substring(splitInput[2].IndexOf(';') + 1);
                if (command.Equals("Add"))
                {
                    if (type.Equals("Starts"))
                    {
                        filtiredPeople = filtiredPeople.Where(n => n.StartsWith(param) == false).ToList();
                    }
                    else if (type.Equals("Ends"))
                    {
                        filtiredPeople = filtiredPeople.Where(n => n.EndsWith(param) == false).ToList();
                    }
                }
                else if (command.Equals("Remove"))
                {
                    if (type.Equals("Starts"))
                    {
                        var currentPeople = people.Where(n => n.StartsWith(param)).ToList();
                        filtiredPeople = filtiredPeople.Concat(currentPeople).ToList();
                    }
                    else if (type.Equals("Ends"))
                    {
                        var currentPeople = people.Where(n => n.EndsWith(param)).ToList();
                        filtiredPeople = filtiredPeople.Concat(currentPeople).ToList();
                    }
                }
            }
            else if (type.Equals("Length"))
            {
                int param = int.Parse(splitInput[2].Substring(splitInput[1].IndexOf(';') + 1));
                if (command.Equals("Add"))
                {
                    filtiredPeople = filtiredPeople.Where(n => n.Length != param).ToList();
                }
                else if (command.Equals("Remove"))
                {
                    var currentPeople = people.Where(n => n.Length == param).ToList();
                    filtiredPeople = filtiredPeople.Concat(currentPeople).ToList();
                }
            }
            else if (type.Equals("Contains"))
            {
                string param = string.Empty;
                param = splitInput[2].Substring(splitInput[2].IndexOf(';') + 1);
                if (command.Equals("Add"))
                {
                    filtiredPeople = filtiredPeople.Where(n => n.Contains(param) == false).ToList();
                }
                else if (command.Equals("Remove"))
                {
                    var currentPeople = people.Where(n => n.Contains(param)).ToList();
                    filtiredPeople = filtiredPeople.Concat(currentPeople).ToList();
                }
            }
            input = Console.ReadLine();
        }
        Console.WriteLine(string.Join(" ", filtiredPeople.OrderByDescending(n => n)));
    }
}