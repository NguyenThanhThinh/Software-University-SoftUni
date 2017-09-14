public class JobFactory
{
    public Job OpenJob(Employee employee, string name, int hoursOfWorkRequired)
    {
        return new Job(employee, name, hoursOfWorkRequired);
    }
}