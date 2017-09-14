using System;
using System.Linq;
using System.Reflection;
using _10.Inferno_Infinity.IO;
using _10.Inferno_Infinity.Factory;
using _11.Custom_Attribute;

namespace _10.Inferno_Infinity.Engine
{
    public class Engine
    {
        public void Start()
        {
            string input = ReadLine.Read();

            while (!input.Equals("END"))
            {
                ProcessTheCommand(input);
                input = ReadLine.Read();
            }
        }

        //Refactor this to a separate class Command???
        //Also the attribute can be moved in some other class may be, but I will leave them here for now
        //The Attributes part was added latter from different exercise and was not implemented in the best possible way
        private void ProcessTheCommand(string input)
        {
            var inputSplit = input.Split(';');
            string command = inputSplit[0];
            string name = String.Empty;
            int index = 0;

            // can think of making enum
            if (command != "Author" && command != "Revision" && command != "Description" && command != "Reviewers")
            {
                name = inputSplit[1];
            }

            var attributes = typeof(Weapon).GetCustomAttributes();
            CustomAttribute typeAttribute = attributes.ToArray()[0] as CustomAttribute;

            switch (command)
            {
                case "Create":
                    Repository.Repository.AddWeapon(WeaponFactory.CreateWeapon(input));
                    break;
                case "Add":
                    index = int.Parse(inputSplit[2]);
                    string gem = inputSplit[3];
                    Repository.Repository.Weapons[name].AddGemInSocket(index, GemFactory.CreateGem(gem));
                    break;
                case "Remove":
                    index = int.Parse(inputSplit[2]);
                    Repository.Repository.Weapons[name].RemoveGemFromSocket(index);
                    break;
                case "Print":
                    WriteLine.Write(Repository.Repository.Weapons[name].ToString());
                    break;
                case "Author":
                    WriteLine.Write($"Author: {typeAttribute.Author}");
                    break;
                case "Revision":
                    WriteLine.Write($"Revision: {typeAttribute.Revision}");
                    break;
                case "Description":
                    WriteLine.Write($"Class description: {typeAttribute.Description}");
                    break;
                case "Reviewers":
                    WriteLine.Write($"Reviewers: {typeAttribute.Reviewers}");
                    break;
            }
        }
    }
}