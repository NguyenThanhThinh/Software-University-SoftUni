public class EmployeeFactory
{
    public PartTimeEmployee PartTime(string name)
    {
        return new PartTimeEmployee(name);
    }

    public StandartEmployee Standart(string name)
    {
        return new StandartEmployee(name);
    }
}