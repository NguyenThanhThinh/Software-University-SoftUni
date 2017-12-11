namespace Mapping.Commands
{
    using System;
    using Services.Contracts;

    public class ExitCommand : Command
    {
        public ExitCommand(IEmployeeService employeeService)
            : base(employeeService)
        {
        }

        public override string Execute(params string[] tokens)
        {
            Environment.Exit(1);
            return "";
        }
    }
}