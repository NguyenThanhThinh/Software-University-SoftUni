public abstract class Employee : IEmployee
{
    private string name;
    private int workHoursPerWeek;

    public Employee(string name, int workHoursPerWeek)
    {
        this.Name = name;
        this.WorkHoursPerWeek = workHoursPerWeek;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int WorkHoursPerWeek
    {
        get { return workHoursPerWeek; }
        protected set { workHoursPerWeek = value; }
    }
}
