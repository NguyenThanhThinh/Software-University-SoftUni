public class Easy : Mission
{
    private const string MissionName = "Suppression of civil rebellion";

    public Easy(double scoreToComplete)
        : base(MissionName, scoreToComplete)
    {
    }

    public override double EnduranceRequired
    {
        get { return 20d; }
    }
}