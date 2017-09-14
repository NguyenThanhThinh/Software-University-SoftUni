using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_10.STAR_STAR_STAR_Family_Tree
{
    class Person
    {
        public Person(string name, string dateOfBirth)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Parents = new List<Person>();
            this.Childs = new List<Person>();
        }

        public List<Person> Parents { get; set; }
        public List<Person> Childs { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string fisrCommand = Console.ReadLine();
            string input = Console.ReadLine();

            List<Person> familyMembers = new List<Person>();

            List<string> commandHistory = new List<string>();

            //get all commands
            input = CreateHistory(input, commandHistory);

            //contains only relationships commands 
            List<string> treeCommands = new List<string>();

            //extract family members data and filters the command stack
            CreateFamily(familyMembers, commandHistory, treeCommands);

            PopulateRelationships(familyMembers, treeCommands);

            PrintResult(fisrCommand, familyMembers);
        }

        private static void CreateFamily(List<Person> familyMembers, List<string> commandHistory, List<string> treeCommands)
        {
            foreach (string command in commandHistory)
            {
                if (!command.Contains("-"))
                {
                    // person data
                    AddFamilyMembers(familyMembers, command);
                }
                else
                {
                    // relationships data
                    treeCommands.Add(command);
                }
            }
        }

        private static void PrintResult(string fisrCommand, List<Person> familyMembers)
        {
            if (fisrCommand != null)
            {
                Person resulPerson;
                if (fisrCommand.Contains("/"))
                {
                    //find by date
                    resulPerson = familyMembers.Find(x => x.DateOfBirth == fisrCommand);
                }
                else
                {
                    //find by name
                    resulPerson = familyMembers.Find(x => x.Name == fisrCommand);
                }

                Console.WriteLine($"{resulPerson.Name} {resulPerson.DateOfBirth}");
                Console.WriteLine("Parents:");
                if (resulPerson.Parents.Count > 0)
                {

                    resulPerson.Parents.ForEach(x => Console.WriteLine($"{x.Name} {x.DateOfBirth}"));
                }
                Console.WriteLine("Children:");

                if (resulPerson.Childs.Count > 0)
                {
                    resulPerson.Childs.ForEach(x => Console.WriteLine($"{x.Name} {x.DateOfBirth}"));
                }

            }
        }

        private static void PopulateRelationships(List<Person> familyMembers, List<string> treeCommands)
        {
            foreach (var comm in treeCommands)
            {
                string[] commands = comm.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commands[0].Contains("/"))
                {
                    // <date> <???>
                    if (commands[1].Contains("/"))
                    {
                        // <date> <date>
                        Person parent = familyMembers.First(x => x.DateOfBirth == commands[0]);
                        Person child = familyMembers.First(x => x.DateOfBirth == commands[1]);

                        parent.Childs.Add(child);
                        child.Parents.Add(parent);
                    }
                    else
                    {
                        // <date> <name>
                        Person parent = familyMembers.First(x => x.DateOfBirth == commands[0]);
                        Person child = familyMembers.First(x => x.Name == commands[1]);

                        parent.Childs.Add(child);
                        child.Parents.Add(parent);
                    }
                }
                else
                {
                    // <name> <???>
                    if (commands[1].Contains("/"))
                    {
                        // <name> <date>
                        Person parent = familyMembers.First(x => x.Name == commands[0]);
                        Person child = familyMembers.First(x => x.DateOfBirth == commands[1]);

                        parent.Childs.Add(child);
                        child.Parents.Add(parent);
                    }
                    else
                    {
                        // <name> <name>
                        Person parent = familyMembers.First(x => x.Name == commands[0]);
                        Person child = familyMembers.First(x => x.Name == commands[1]);

                        parent.Childs.Add(child);
                        child.Parents.Add(parent);
                    }
                }

            }
        }

        private static void AddFamilyMembers(List<Person> persons, string command)
        {
            string[] commands = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = commands[0] + " " + commands[1];
            Person person = new Person(name, commands[2]);
            persons.Add(person);
        }

        private static string CreateHistory(string input, List<string> history)
        {
            while (input != "End")
            {
                history.Add(input);
                input = Console.ReadLine();
            }

            return input;
        }
    }
}
