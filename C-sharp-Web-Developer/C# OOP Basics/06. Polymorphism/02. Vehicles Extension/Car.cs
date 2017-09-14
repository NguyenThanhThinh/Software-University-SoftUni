public class Car : Vihicle
{
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
        IncreaseOfConsumption();
    }

    public override void IncreaseOfConsumption()
    {
        FuelConsumption += 0.9d;
    }

    public override void RefuelTank(double fuel)
    {
        FuelQuantity += fuel;
    }
}