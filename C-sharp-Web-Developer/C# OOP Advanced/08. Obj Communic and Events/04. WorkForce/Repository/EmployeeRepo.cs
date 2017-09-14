using System.Collections.Generic;

public class EmployeeRepo
{
    private List<Employee> employees;

    public EmployeeRepo()
    {
        this.Employees = new List<Employee>();
    }

    public List<Employee> Employees
    {
        get { return employees; }
        set { employees = value; }
    }
}