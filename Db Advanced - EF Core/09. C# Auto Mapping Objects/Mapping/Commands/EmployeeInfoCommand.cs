namespace Mapping.Commands
{
    using Services.Contracts;

    public class EmployeeInfoCommand : Command
    {
        public EmployeeInfoCommand(IEmployeeService employeeService)
            : base(employeeService)
        {
        }

        public override string Execute(params string[] tokens)
        {
            string result = this.CheckParamsCount(1, tokens);

            if (result == InvalidParams)
            {
                return result;
            }

            int emplId = int.Parse(tokens[0]);

            result = this.EmployeeService.EmployeeInfo(emplId);

            return result;
        }
    }
}