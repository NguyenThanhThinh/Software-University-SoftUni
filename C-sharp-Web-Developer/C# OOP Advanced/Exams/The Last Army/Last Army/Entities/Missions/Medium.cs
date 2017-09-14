public class Medium : Mission
{
    private const string MissionName = "Capturing dangerous criminals";

    public Medium(double scoreToComplete)
        : base(MissionName, scoreToComplete)
    {
    }

    public override double EnduranceRequired
    {
        get { return 50d; }
    }
}