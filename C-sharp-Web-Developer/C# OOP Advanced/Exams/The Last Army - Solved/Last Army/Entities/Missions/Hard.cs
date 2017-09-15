public class Hard : Mission
{
    private const string MissionName = "Disposal of terrorists";

    public Hard(double scoreToComplete)
        : base(MissionName, scoreToComplete)
    {
    }

    public override double EnduranceRequired
    {
        get { return 80d; }
    }
}