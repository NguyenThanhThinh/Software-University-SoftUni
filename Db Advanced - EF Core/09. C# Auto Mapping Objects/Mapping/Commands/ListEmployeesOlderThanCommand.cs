namespace Mapping.Commands
{
    using Services.Contracts;

    public class ListEmployeesOlderThanCommand : Command
    {
        public ListEmployeesOlderThanCommand(IEmployeeService employeeService) : base(employeeService)
        {
        }

        public override string Execute(params string[] tokens)
        {
            string result = this.CheckParamsCount(1, tokens);

            if (result == InvalidParams)
            {
                return result;
            }

            int age = int.Parse(tokens[0]);

            result = this.EmployeeService.ListEmployeesOlderThanGivenAge(age);

            return result;
        }
    }
}