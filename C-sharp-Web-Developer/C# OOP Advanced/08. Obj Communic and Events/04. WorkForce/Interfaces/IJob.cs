public interface IJob
{
    Employee CurrentEmployee { get; }
    string Name { get; }
    int HoursOfWorkRequired { get; }
    void Update();
}