namespace DtoModels
{
    using System.Collections.Generic;

    public class ManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<EmployeeDto> EmployeeDtos { get; set; } = new List<EmployeeDto>();

        public int EmployeesCount { get; set; }
    }
}