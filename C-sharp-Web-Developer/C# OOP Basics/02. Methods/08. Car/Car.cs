public class Car
{
    private decimal speed;
    private decimal fuel;
    private decimal fuelEconomy;

    public Car(decimal speed, decimal fuel, decimal fuelEconomy)
    {
        this.speed = speed;
        this.fuel = fuel;
        this.fuelEconomy = fuelEconomy;
    }

    public decimal Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public decimal Fuel
    {
        get { return fuel; }
        set { fuel = value; }
    }

    public decimal FuelEconomy
    {
        get { return fuelEconomy; }
        set { fuelEconomy = value; }
    }
}