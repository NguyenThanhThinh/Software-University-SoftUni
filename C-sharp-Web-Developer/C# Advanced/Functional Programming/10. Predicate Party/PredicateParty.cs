using System;
using System.Collections.Generic;
using System.Linq;

public static class PredicateParty
{
    public static void Main()
    {
        var peopleComming = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        string commandWithCriteria = Console.ReadLine();
        Action<List<string>, string> removeStartsWithFunc = RemoveStartsWith;
        Action<List<string>, string> doubleStartsWithFunc = DoubleStartsWith;
        Action<List<string>, string> removeEndsWithFunc = RemoveEndsWith;
        Action<List<string>, string> doubleEndsWithFunc = DoubleEndsWith;
        Action<List<string>, int> removeLenghtFunc = RemoveLenght;
        Action<List<string>, int> doubleLenghtFunc = DoubleLenght;

        int lenght = 0;

        while (commandWithCriteria != "Party!")
        {
            var splitCommandWithCriteria = commandWithCriteria.Split();
            string command = splitCommandWithCriteria[0];
            string criteriaCommand = splitCommandWithCriteria[1];
            string criteriaString = splitCommandWithCriteria[2];

            if (command.Equals("Double"))
            {
                if (criteriaCommand.Equals("StartsWith"))
                {
                    doubleStartsWithFunc(peopleComming, criteriaString);
                }
                else if (criteriaCommand.Equals("EndsWith"))
                {
                    doubleEndsWithFunc(peopleComming, criteriaString);
                }
                else if (criteriaCommand.Equals("Length"))
                {
                    lenght = int.Parse(criteriaString);
                    doubleLenghtFunc(peopleComming, lenght);
                }
            }
            else if (command.Equals("Remove"))
            {
                if (criteriaCommand.Equals("StartsWith"))
                {
                    removeStartsWithFunc(peopleComming, criteriaString);
                }
                else if (criteriaCommand.Equals("EndsWith"))
                {
                    removeEndsWithFunc(peopleComming, criteriaString);
                }
                else if (criteriaCommand.Equals("Length"))
                {
                    lenght = int.Parse(criteriaString);
                    removeLenghtFunc(peopleComming, lenght);
                }
            }
            commandWithCriteria = Console.ReadLine();
        }
        if (peopleComming.Count > 0)
        {
            Console.WriteLine($"{string.Join(", ", peopleComming.OrderBy(n => n))} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }

    public static void RemoveStartsWith(List<string> peopleComming, string criteriaString)
    {
        for (int i = 0; i < peopleComming.Count; i++)
        {
            if (peopleComming[i].StartsWith(criteriaString))
            {
                peopleComming.RemoveAt(i);
                i--;
            }
        }
    }

    public static void DoubleStartsWith(List<string> peopleComming, string criteriaString)
    {
        int count = peopleComming.Count;
        for (int i = 0; i < count; i++)
        {
            if (peopleComming[i].StartsWith(criteriaString))
            {
                peopleComming.Add(peopleComming[i]);
            }
        }
    }

    public static void RemoveEndsWith(List<string> peopleComming, string criteriaString)
    {
        for (int i = 0; i < peopleComming.Count; i++)
        {
            if (peopleComming[i].EndsWith(criteriaString))
            {
                peopleComming.RemoveAt(i);
                i--;
            }
        }
    }

    public static void DoubleEndsWith(List<string> peopleComming, string criteriaString)
    {
        int count = peopleComming.Count;
        for (int i = 0; i < count; i++)
        {
            if (peopleComming[i].EndsWith(criteriaString))
            {
                peopleComming.Add(peopleComming[i]);
            }
        }
    }

    public static void RemoveLenght(List<string> peopleComming, int lenght)
    {
        for (int i = 0; i < peopleComming.Count; i++)
        {
            if (peopleComming[i].Length == lenght)
            {
                peopleComming.RemoveAt(i);
                i--;
            }
        }
    }

    public static void DoubleLenght(List<string> peopleComming, int lenght)
    {
        int count = peopleComming.Count;
        for (int i = 0; i < count; i++)
        {
            if (peopleComming[i].Length == lenght)
            {
                peopleComming.Add(peopleComming[i]);
            }
        }
    }
}