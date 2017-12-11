namespace Mapping.Commands
{
    using System;
    using Services.Contracts;

    public class SetAddressCommand : Command
    {
        private const string SetAddressSuccess = "Address of employee with Id {0}, was set successfulyy.";
        private const string SetAddressError = "Address of employee with Id {0}, was not set successfully.";

        public SetAddressCommand(IEmployeeService employeeService)
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
            string address = tokens[1];

            bool success = this.EmployeeService.SetAddress(emplId, address);

            result = success
                ? String.Format(SetAddressSuccess, emplId)
                : String.Format(SetAddressError, emplId);

            return result;
        }
    }
}