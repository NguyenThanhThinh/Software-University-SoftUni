public class Truck : Vihicle
{
    public Truck(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption)
    {
        IncreaseOfConsumption();
    }

    protected override void IncreaseOfConsumption()
    {
        FuelConsumption += 1.6d;
    }

    public override void RefuelTank(double fuel)
    {
        FuelQuantity += fuel * 0.95;
    }
}