namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using DtoModels;
    using Models;

    public class EmployeeService : IEmployeeService
    {
        private const string EmployeeError = "Employee with ID: {1} doesn't exist.";
        private readonly MappingDbContext context;

        public EmployeeService(MappingDbContext context)
        {
            this.context = context;
        }

        public bool AddEmployee(string firstName, string lastName, decimal salary)
        {
            //this.Seed();

            if (salary <= 0)
            {
                return false;
            }

            Employee employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.context.Employees.Add(employee);
            this.context.SaveChanges();

            if (this.context.Employees.FirstOrDefault(e => e.FirstName == firstName && e.LastName == lastName && e.Salary == salary) == null)
            {
                return false;
            }

            return true;
        }

        public bool SetBirthday(int employeeId, string dateFormat)
        {
            Employee empl = this.context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

            if (empl == null)
            {
                return false;
            }

            DateTime newDate = DateTime.ParseExact(dateFormat, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            empl.Birthday = newDate;
            this.context.SaveChanges();

            if (this.context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId && e.Birthday == newDate) == null)
            {
                return false;
            }

            return true;
        }

        public bool SetAddress(int employeeId, string address)
        {
            Employee empl = this.context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

            if (empl == null)
            {
                return false;
            }

            empl.Address = address;

            this.context.SaveChanges();

            if (this.context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId && e.Address == address) == null)
            {
                return false;
            }

            return true;
        }

        public string EmployeeInfo(int employeeId)
        {
            var empl = this.context.Employees
                .Where(e => e.EmployeeId == employeeId)
                .ProjectTo<EmployeeDto>()
                .SingleOrDefault();

            if (empl == null)
            {
                return string.Format(EmployeeError, employeeId);
            }

            var sb = new StringBuilder();

            sb.AppendLine($"ID: {employeeId} - {empl.FirstName} {empl.LastName} - ${empl.Salary:F2}");

            return sb.ToString();
        }

        public string EmployeeFullInfo(int employeeId)
        {
            var sb = new StringBuilder(this.EmployeeInfo(employeeId));

            if (sb.ToString().Contains("doesn't exist."))
            {
                return string.Format(EmployeeError, employeeId);
            }

            var empl = this.context.Employees
                .Where(e => e.EmployeeId == employeeId)
                .ProjectTo<EmployeeFullInfoDto>()
                .SingleOrDefault();

            sb.AppendLine(empl.Birthday != null
                ? $"Birthday: {empl.Birthday.Value.ToShortDateString()}"
                : $"Birthday: {empl.Birthday}");

            sb.AppendLine($"Address: {empl.Address}");

            return sb.ToString();
        }

        public bool SetEmployeeManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.SingleOrDefault(emp => emp.EmployeeId == employeeId);
            var manager = this.context.Employees.SingleOrDefault(emp => emp.EmployeeId == managerId);

            if (employee == null || manager == null)
            {
                return false;
            }

            this.context.Employees
                .SingleOrDefault(empl => empl.EmployeeId == employeeId)
                .ManagerId = managerId;
            this.context.SaveChanges();

            return true;
        }

        public string GetManagerInfo(int managerId)
        {
            var sb = new StringBuilder();

            ManagerDto manager = this.context.Employees
                .Where(m => m.EmployeeId == managerId)
                .ProjectTo<ManagerDto>()
                .FirstOrDefault();

            sb.AppendLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.EmployeesCount}");

            foreach (var employee in manager.EmployeeDtos)
            {
                sb.AppendLine($"- {employee.FirstName} {employee.LastName} - ${employee.Salary:F2}");
            }

            return sb.ToString();
        }

        public string ListEmployeesOlderThanGivenAge(int age)
        {
            var sb = new StringBuilder();

            var employees = this.context.Employees
                .Where(emp =>
                    (DateTime.Today.Year - emp.Birthday.Value.Year) > age)
                .ProjectTo<EmployeeInfoByGivenAgeDto>()
                .ToArray();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - ${emp.Salary:F2} - Manager: {emp.Manager}");
            }

            return sb.ToString();
        }

        public void Seed()
        {
            this.context.Employees
                .AddRange(new List<Employee>
                {
                    this.GenerateEmployee("Ivan", "Ivanov", "3000", "20-04-1989"),
                    this.GenerateEmployee("Stefan", "Petrov", "30320", "20-04-1991"),
                    this.GenerateEmployee("Petyr", "Haralampaliev", "3400", "20-04-1990"),
                    this.GenerateEmployee("Maria", "Stefanova", "5000", "20-04-1989"),
                    this.GenerateEmployee("Stefka", "Gaydarska", "1040", "20-04-1987"),
                    this.GenerateEmployee("Suzana", "Suzanova", "1070", "20-04-1986"),
                    this.GenerateEmployee("Kiro", "Kirov", "3000", "20-04-1984"),
                    this.GenerateEmployee("Duci", "Ducov", "30320", "20-04-1997"),
                    this.GenerateEmployee("Susha", "Sushav", "340", "20-04-1999"),
                    this.GenerateEmployee("Sasho", "Sashov", "50234", "20-04-1980"),
                    this.GenerateEmployee("Blagoy", "Blagoyov", "170", "20-04-1982"),
                    this.GenerateEmployee("Valeri", "Bojinov", "10560", "20-04-1981")
                });

            this.context.SaveChanges();

            this.SetManagersToEmployees();
        }

        private Employee GenerateEmployee(string firstName, string lastName, string salary, string birthday)
        {
            decimal convertedSalary = decimal.Parse(salary);
            DateTime convertedBirthday = DateTime.ParseExact(birthday, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            return new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = convertedSalary,
                Birthday = convertedBirthday
            };
        }

        private void SetManagersToEmployees()
        {
            var empCount = this.context.Employees.Count();
            int managerId = 3;

            var allEmployees = this.context.Employees.ToList();

            for (int i = 2; i < empCount; i++)
            {
                allEmployees
                    .Single(emp => emp.EmployeeId == i && emp.EmployeeId != managerId)
                    .ManagerId = managerId;

                if (i > 7)
                {
                    managerId = 5;
                }
            }

            this.context.SaveChanges();
        }
    }
}