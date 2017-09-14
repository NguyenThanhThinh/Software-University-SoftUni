using System;
using System.Collections.Generic;
using System.Text;

namespace _09.TeamWork_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            
            StringBuilder messages = new StringBuilder();
            string person = "";
            string club = "";

            for (int i = 0; i < n; i++)
            {
                var namesCreateClub = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                person = namesCreateClub[0];
                club = namesCreateClub[1];

                if (!ContainsClub(teams, club))
                {
                    if (ContainsPerson(teams, person))
                    {
                        messages.Append(person + " cannot create another team!");
                        messages.AppendLine();
                    }
                    else
                    {
                        Team team = new Team();
                        team.Name = club;
                        team.Creator = person;
                        teams.Add(team);
                        messages.Append("Team " + club + " has been created by " + person + "!");
                        messages.AppendLine();
                    }
                }
                else
                {
                    //this if to be checked if it should exist
                    if (ContainsPerson(teams, person))
                    {
                        messages.Append(person + " cannot create another team!");
                        messages.AppendLine();
                    }
                    messages.Append("Team " + club + " was already created!");
                    messages.AppendLine();
                }
            }

            string commands = Console.ReadLine();

            while (commands != "end of assignment")
            {
                var separateCommands = commands.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                person = separateCommands[0];
                club = separateCommands[1];

                if (!ContainsClub(teams, club))
                {
                    messages.Append("Team " + club + " does not exist!");
                    messages.AppendLine();
                }
                else
                {
                    if (ContainsPerson(teams, person) || MemberOfATeam(teams, person))
                    {
                        messages.Append("Member " + person + " cannot join team " + club + "!");
                        messages.AppendLine();
                    }
                    else
                    {
                        int index = ReturnToWhichTeamToAddMember(teams, club);
                        teams[index].Members.Add(person);
                    }
                }
                commands = Console.ReadLine();
            }

            Console.WriteLine(messages);
            Console.WriteLine();
        }

        public static bool ContainsClub(List<Team> team, string club)
        {
            for (int i = 0; i < team.Count; i++)
            {
                if (team[i].Name == club)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ContainsPerson(List<Team> team, string person)
        {
            for (int i = 0; i < team.Count; i++)
            {
                if (team[i].Creator == person)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool MemberOfATeam(List<Team> team, string person)
        {
            for (int i = 0; i < team.Count; i++)
            {
                for (int p = 0; p < team[i].Members.Count; p++)
                {
                    if (team[i].Members[p] == person)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int ReturnToWhichTeamToAddMember(List<Team> team, string club)
        {
            for (int i = 0; i < team.Count; i++)
            {
                if (team[i].Name == club)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}