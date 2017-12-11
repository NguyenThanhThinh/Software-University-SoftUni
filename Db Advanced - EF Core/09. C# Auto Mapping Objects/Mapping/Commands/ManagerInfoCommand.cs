namespace Mapping.Commands
{
    using Services.Contracts;

    public class ManagerInfoCommand : Command
    {
        public ManagerInfoCommand(IEmployeeService employeeService)
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

            int managerId = int.Parse(tokens[0]);

            result = this.EmployeeService.GetManagerInfo(managerId);

            return result;
        }
    }
}