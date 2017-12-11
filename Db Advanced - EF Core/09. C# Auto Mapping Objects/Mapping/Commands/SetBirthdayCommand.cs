namespace Mapping.Commands
{
    using Services.Contracts;

    public class SetBirthdayCommand : Command
    {
        private const string SetBirthdaySuccess = "Birthday of employee with Id {0} was set to {1}";
        private const string SetBirthdayError = "Birthday of employee with Id {0} was not set successfully.";

        public SetBirthdayCommand(IEmployeeService employeeService)
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

            int emplId = int.Parse(tokens[0]);
            string dateFormat = tokens[1];

            bool success = this.EmployeeService.SetBirthday(emplId, dateFormat);

            result = success
                ? string.Format(SetBirthdaySuccess, emplId, dateFormat)
                : string.Format(SetBirthdayError, emplId);

            return result;
        }
    }
}