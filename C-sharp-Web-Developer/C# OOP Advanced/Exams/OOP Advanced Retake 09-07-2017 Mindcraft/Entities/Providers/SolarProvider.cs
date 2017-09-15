public class SolarProvider : Provider
{
    private const double DurabilityConst = 1000d;
    private const double DurabilityLost = 500d;


    public SolarProvider(int id, double energyOutput)
        : base(id, DurabilityConst, energyOutput)
    {
        this.Durability += DurabilityLost;
    }
}