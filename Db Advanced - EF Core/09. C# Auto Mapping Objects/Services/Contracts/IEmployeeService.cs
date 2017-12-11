namespace Services.Contracts
{
    public interface IEmployeeService
    {
        bool AddEmployee(string firstName, string lastName, decimal salary);

        bool SetBirthday(int employeeId, string dateFormat);

        bool SetAddress(int employeeId, string address);

        string EmployeeInfo(int employeeId);

        string EmployeeFullInfo(int employeeId);

        bool SetEmployeeManager(int employeeId, int managerId);

        string GetManagerInfo(int managerId);

        string ListEmployeesOlderThanGivenAge(int age);
    }
}