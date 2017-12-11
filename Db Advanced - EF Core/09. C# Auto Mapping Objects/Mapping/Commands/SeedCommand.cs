namespace Mapping.Commands
{
    using Services.Contracts;

    public class SeedCommand : Command
    {
        public SeedCommand(IEmployeeService employeeService) : base(employeeService)
        {
        }

        public override string Execute(params string[] tokens)
        {
            throw new System.NotImplementedException();
        }
    }
}