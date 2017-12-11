namespace Mapping.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Commands;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CommandParser(string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly.GetTypes()
                .ToArray();

            //var commands = commandTypes
            //    .Where(t => t.BaseType != null && t.BaseType.IsAbstract && t.Name.EndsWith("Command"))
            //    .ToArray();

            var commandType = commandTypes.SingleOrDefault(c => c.Name.Equals(commandName));

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var command = this.InjectServices(commandType);

            return command;
        }

        private ICommand InjectServices(Type commandType)
        {
            var ctor = commandType.GetConstructors().First();

            var constructorParameters = ctor.GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            var services = constructorParameters
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var command = (Command)ctor.Invoke(services);

            return command;
        }
    }
}