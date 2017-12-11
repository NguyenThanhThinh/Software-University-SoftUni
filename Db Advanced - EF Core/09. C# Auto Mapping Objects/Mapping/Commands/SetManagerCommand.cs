namespace Mapping.Commands
{
    using Services.Contracts;

    public class SetManagerCommand : Command
    {
        private const string SetManagerSuccess = "Manager have been assigned to employee with Id: {0}.";
        private const string SetManagerError = "Employee manager assigned was failed.";

        public SetManagerCommand(IEmployeeService employeeService)
            : base(employeeService)
        {
        }

        public override string Execute(params string[] tokens)
        {
            string result = this.CheckParamsCount(2, tokens);

            if (result == InvalidParams)
            {
                return result;
            }

            int employeeId = int.Parse(tokens[0]);
            int managerId = int.Parse(tokens[1]);

            bool success = this.EmployeeService.SetEmployeeManager(employeeId, managerId);

            if (success)
            {
                result = string.Format(SetManagerSuccess, employeeId);
                return result;
            }

            result = SetManagerError;

            return result;
        }
    }
}