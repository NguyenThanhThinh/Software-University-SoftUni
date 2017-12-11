namespace Mapping.Commands
{
    using Services.Contracts;

    public class AddEmployeeCommand : Command
    {
        private const string EmployeeError = "Employee was not added successfully.";

        public AddEmployeeCommand(IEmployeeService employeeService)
            : base(employeeService)
        {
        }

        public override string Execute(params string[] tokens)
        {
            if (tokens.Length != 3)
            {
                return InvalidParams;
            }

            string firstName = tokens[0];
            string lastName = tokens[1];
            decimal salary = decimal.Parse(tokens[2]);

            bool success = this.EmployeeService.AddEmployee(firstName, lastName, salary);

            if (success)
            {
                return $"Employee {firstName} {lastName} was added.";
            }

            return EmployeeError;
        }
    }
}