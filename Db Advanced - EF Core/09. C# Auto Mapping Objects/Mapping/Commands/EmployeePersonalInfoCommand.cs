namespace Mapping.Commands
{
    using Services.Contracts;

    public class EmployeePersonalInfoCommand : Command
    {
        public EmployeePersonalInfoCommand(IEmployeeService employeeService)
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

            result = this.EmployeeService.EmployeeFullInfo(emplId);

            return result;
        }
    }
}