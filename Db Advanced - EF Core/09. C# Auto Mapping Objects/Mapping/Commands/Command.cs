namespace Mapping.Commands
{
    using Contracts;
    using Services.Contracts;

    public abstract class Command : ICommand
    {
        protected const string InvalidParams = "Invalid Parameters.";
        protected readonly IEmployeeService EmployeeService;

        protected Command(IEmployeeService employeeService)
        {
            this.EmployeeService = employeeService;
        }

        public abstract string Execute(params string[] tokens);

        protected string CheckParamsCount(int count, string[] tokens)
        {
            if (tokens.Length != count)
            {
                return InvalidParams;
            }

            return string.Empty;
        }
    }
}