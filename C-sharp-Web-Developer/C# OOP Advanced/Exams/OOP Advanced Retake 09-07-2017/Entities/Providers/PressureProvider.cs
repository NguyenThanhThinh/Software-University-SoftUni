using System;
public class PressureProvider : Provider
{
    private const double DurabilityConst = 1000d;
    private const double DurabilityLost = 300d;
    private const double EnergyLost = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, DurabilityConst, energyOutput)
    {
        this.Durability -= DurabilityLost;
        this.EnergyOutput *= EnergyLost;
    }
}
