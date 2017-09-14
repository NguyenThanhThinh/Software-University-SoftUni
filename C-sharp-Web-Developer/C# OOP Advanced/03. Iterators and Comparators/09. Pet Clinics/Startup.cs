using System;
using System.Collections.Generic;

namespace _09.Pet_Clinics
{
    public class Startup
    {
        public static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            var clinics = new Dictionary<string, Clinic>();
            var pets = new Dictionary<string, Pet>();
            string clinicName = String.Empty;

            for (int i = 0; i < numberOfCommands; i++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            if (input[1].Equals("Pet"))
                            {
                                string name = input[2];
                                int age = int.Parse(input[3]);
                                string kind = input[4];

                                pets.Add(name, new Pet(name, age, kind));
                            }
                            else if (input[1].Equals("Clinic"))
                            {
                                string name = input[2];
                                int numberOfRooms = int.Parse(input[3]);

                                clinics.Add(name, new Clinic(new Pet[numberOfRooms], name));
                            }
                            break;
                        case "Add":
                            string petName = input[1];
                            clinicName = input[2];
                            Pet pet = pets[petName];

                            Console.WriteLine(clinics[clinicName].Add(pet));
                            break;
                        case "Release":
                            clinicName = input[1];
                            Console.WriteLine(clinics[clinicName].Release());
                            break;
                        case "HasEmptyRooms":
                            clinicName = input[1];
                            Console.WriteLine(clinics[clinicName].HasEmptyRooms());
                            break;
                        case "Print":
                            clinicName = input[1];
                            if (input.Length == 2)
                            {
                                clinics[clinicName].Print();
                            }
                            else if (input.Length == 3)
                            {
                                int clinicRoom = int.Parse(input[2]);
                                clinics[clinicName].Print(clinicRoom);
                            }
                            break;
                    }
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }
            }
        }
    }
}