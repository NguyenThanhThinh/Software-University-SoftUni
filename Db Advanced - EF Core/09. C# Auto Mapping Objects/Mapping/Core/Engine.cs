namespace Mapping.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Contracts;

    public class Engine : IEngine
    {
        private const string CommandSuffix = "Command";

        private readonly ICommandInterpreter commandInterpreter;
        private readonly IServiceProvider serviceProvider;

        public Engine(ICommandInterpreter commandInterpreter, IServiceProvider serviceProvider)
        {
            this.commandInterpreter = commandInterpreter;
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var dbInitilizer = this.serviceProvider.GetService<IDatabaseInitializerService>();
            dbInitilizer.InitializeDatabase();

            while (true)
            {
                string input = Console.ReadLine();

                string[] args = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = args[0] + CommandSuffix;

                string[] tokens = args.Skip(1).Take(args.Length - 1).ToArray();

                ICommand actualCommand = this.commandInterpreter.CommandParser(command);

                string result = actualCommand.Execute(tokens);

                Console.WriteLine(result.Trim());
            }
        }
    }
}