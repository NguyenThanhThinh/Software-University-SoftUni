using System.Linq;
using System.Reflection;
using _04.BarrackWars_Commands_Strike_Back.Core.Commands;

namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        //public static StringBuilder sb = new StringBuilder();

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                    //sb.AppendLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;

            try
            {
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name.ToLower() == commandName.ToLower());
                var command = (Command)Activator.CreateInstance(currentType, data, this.repository, this.unitFactory);
                result = command.Execute();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            return result;
        }
    }
}