using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class SoftuniKaraoke
{
    static void Main()
    {
        var participants = Console.ReadLine().Split(new char[] { ' ', ',', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var songs = Console.ReadLine();
        var performance = Console.ReadLine();
        var finalResults = new Dictionary<string, SortedSet<string>>();
        bool notEmpty = false;

        string pattern = @"[^,]+";
        Regex regexSongs = new Regex(pattern);
        MatchCollection matchesSongs = regexSongs.Matches(songs);
        var listSongs = GetListOfSongs(matchesSongs);

        while (performance != "dawn")
        {
            Regex regexPerformance = new Regex(pattern);
            MatchCollection matchPerformance = regexPerformance.Matches(performance);
            var participant = matchPerformance[0].Value.Trim();
            var song = matchPerformance[1].Value.Trim();
            var award = matchPerformance[2].Value.Trim();

            if (participants.Contains(participant) && songs.Contains(song))
            {
                if (!finalResults.ContainsKey(participant))
                {
                    finalResults[participant] = new SortedSet<string>();
                    finalResults[participant].Add(award);
                }
                else
                {
                    finalResults[participant].Add(award);
                }
                notEmpty = true;
            }
            performance = Console.ReadLine();
        }

        if (notEmpty)
        {
            foreach (var person in finalResults.OrderByDescending(n => n.Value.Count).ThenBy(m => m.Key))
            {
                Console.WriteLine($"{person.Key}: {person.Value.Count} awards");
                foreach (var award in person.Value)
                {
                    Console.WriteLine($"--{award}");
                }
            }
        }
        else
        {
            Console.WriteLine("No awards");
        }
    }

    private static List<string> GetListOfSongs(MatchCollection matchesSongs)
    {
        List<string> songs = new List<string>();
        foreach (Match song in matchesSongs)
        {
            string currentSong = song.Value.Trim();
            songs.Add(currentSong);
        }
        return songs;
    }
}