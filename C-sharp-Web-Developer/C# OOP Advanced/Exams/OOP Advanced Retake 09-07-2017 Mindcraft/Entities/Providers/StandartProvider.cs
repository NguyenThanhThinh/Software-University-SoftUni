public class StandartProvider : Provider
{
    private const double DurabilityConst = 1000d;

    public StandartProvider(int id, double energyOutput)
        : base(id, DurabilityConst, energyOutput)
    {
    }
}