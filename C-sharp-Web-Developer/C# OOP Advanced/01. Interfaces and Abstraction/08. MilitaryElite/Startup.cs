using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var privates = new Dictionary<int, Soldier>();
            List<Soldier> soldiers = new List<Soldier>();

            while (!input[0].Equals("End"))
            {
                int id = int.Parse(input[1]);
                string firstName = input[2];
                string lastName = input[3];
                string corps;

                switch (input[0])
                {
                    case "Private":
                        double salary = double.Parse(input[4]);
                        Soldier soldier = new Private(id, firstName, lastName, salary);
                        privates[id] = soldier;
                        soldiers.Add(soldier);
                        break;
                    case "LeutenantGeneral":
                        double generalSalary = double.Parse(input[4]);
                        List<Private> generalPrivates = new List<Private>();

                        for (int i = 5; i < input.Length; i++)
                        {
                            int keyId = int.Parse(input[i]);
                            Soldier currentSoldier = privates[keyId];
                            generalPrivates.Add((Private)currentSoldier);
                        }
                        Soldier leutenant = new LeutenantGeneral(id, firstName, lastName, generalSalary, generalPrivates);
                        soldiers.Add(leutenant);
                        break;
                    case "Engineer":
                        double engineerSalary = double.Parse(input[4]);
                        corps = input[5];
                        List<Repairs> repairs = new List<Repairs>();

                        for (int i = 6; i < input.Length; i += 2)
                        {
                            var partName = input[i];
                            var workedHours = int.Parse(input[i + 1]);
                            repairs.Add(new Repairs(partName, workedHours));
                        }

                        try
                        {
                            Soldier engineer = new Engineer(id, firstName, lastName, engineerSalary, corps, repairs);
                            soldiers.Add(engineer);
                        }
                        catch (ArgumentException arg)
                        {
                        }
                        break;
                    case "Commando":
                        double commandoSalary = double.Parse(input[4]);
                        corps = input[5];
                        List<Mission> missions = new List<Mission>();

                        for (int i = 6; i < input.Length; i += 2)
                        {
                            try
                            {
                                var codeName = input[i];
                                var state = input[i + 1];
                                missions.Add(new Mission(codeName, state));
                            }
                            catch (ArgumentException arg)
                            {
                            }
                        }
                        try
                        {
                            Soldier commando = new Commando(id, firstName, lastName, commandoSalary, corps, missions);
                            soldiers.Add(commando);
                        }
                        catch (ArgumentException arg)
                        {
                        }
                        break;
                    case "Spy":
                        var codeNumber = input[4];
                        Soldier spy = new Spy(id, firstName, lastName, codeNumber);
                        soldiers.Add(spy);
                        break;
                }
                input = Console.ReadLine().Split();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}