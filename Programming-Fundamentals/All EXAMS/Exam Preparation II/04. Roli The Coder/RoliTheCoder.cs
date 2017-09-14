using System;
using System.Collections.Generic;
using System.Linq;

class RoliTheCoder
{
    static void Main()
    {
        string line = Console.ReadLine();
        var events = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

        while (line != "Time for Code")
        {
            var values = line.Split(new char[] { '\n', '\t', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var validInput = CheckIfInputIsValid(values);

            if (validInput)
            {
                string id = values[0];
                string eventName = values[1].TrimStart('#');
                SortedSet<string> participants = new SortedSet<string>();
                participants = AddParticipants(values);

                if (!events.ContainsKey(id))
                {
                    events[id] = new Dictionary<string, SortedSet<string>>();
                    events[id][eventName] = new SortedSet<string>();
                    events[id][eventName] = participants;
                }
                else
                {
                    if (events[id].ContainsKey(eventName))
                    {
                        foreach (var participant in participants)
                        {
                            events[id][eventName].Add(participant.ToString());
                        }
                    }
                }
            }
            validInput = false;
            line = Console.ReadLine();
        }

        foreach (var singleEvent in events.OrderByDescending(s => s.Value.First().Value.Count()))
        {
            Console.WriteLine($"{singleEvent.Value.First().Key} - {singleEvent.Value.First().Value.Count()}");
            foreach (var participants in singleEvent.Value.First().Value)
            {
                Console.WriteLine($"{participants}");
            }
        }
    }

    private static SortedSet<string> AddParticipants(string[] values)
    {
        SortedSet<string> participants = new SortedSet<string>();

        for (int i = 2; i < values.Length; i++)
        {
            participants.Add(values[i]);
        }
        return participants;
    }

    private static bool CheckIfInputIsValid(string[] values)
    {
        if (!values[1].StartsWith("#"))
        {
            return false;
        }
        else if (true)
        {
            for (int i = 2; i < values.Length; i++)
            {
                if (!values[i].StartsWith("@"))
                {
                    return false;
                }
            }
        }
        return true;
    }
}