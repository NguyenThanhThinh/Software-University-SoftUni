using _04.BarrackWars_Commands_Strike_Back.Core.Commands;
using _05.BarrackWar__ReturnDependencies;
using System;
using System.Globalization;
using System.Reflection;
using System.Linq;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandsNamespacePath = "_04.BarrackWars_Commands_Strike_Back.Core.Commands.";
        //private const string CommandSuffix = "Command";

        private IUnitFactory unitFactory;
        private IRepository repository;

        public CommandInterpreter(IUnitFactory unitFactory, IRepository repository)
        {
            this.unitFactory = unitFactory;
            this.repository = repository;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandFullName =
                CommandsNamespacePath +
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName);
            //_04.BarrackWars_Commands_Strike_Back.Core.Commands
            object[] commandParameters = new object[] { data };

            IExecutable command = null;
            try
            {
                //throws exception here
                command = (Command)Activator.CreateInstance(Type.GetType(commandFullName), commandParameters);
            }
            catch
            {
                throw new InvalidOperationException("Invalid command!");
            }

            command = this.InjectDependencies(command);
            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] fieldsOfCommand = command.GetType()
                                              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] fieldsOfInterpreter = typeof(CommandInterpreter)
                                              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));
                if (fieldAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == field.FieldType))
                    {
                        field.SetValue(command,
                            fieldsOfInterpreter.First(x => x.FieldType == field.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return command;
        }
    }
}
