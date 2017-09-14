public class Car : Vihicle
{
    public Car(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption)
    {
        IncreaseOfConsumption();
    }

    protected override void IncreaseOfConsumption()
    {
        FuelConsumption += 0.9d;
    }

    public override void RefuelTank(double fuel)
    {
        FuelQuantity += fuel;
    }
}