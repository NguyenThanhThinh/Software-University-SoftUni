
public class EnergyRepository : IEnergyRepository
{
    private double energyStored;

    public double EnergyStored
    {
        get { return this.energyStored; }
    }

    public bool TakeEnergy(double energyNeeded)
    {
        if (energyNeeded <= this.energyStored)
        {
            this.energyStored -= energyNeeded;
            return true;
        }
        return false;
    }

    public void StoreEnergy(double energy)
    {
        this.energyStored += energy;
    }
}