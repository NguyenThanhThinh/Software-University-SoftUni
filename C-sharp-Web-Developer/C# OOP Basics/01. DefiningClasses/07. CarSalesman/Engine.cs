public class Engine
{
    public string model;
    public double power;
    public double displacement;
    public string efficiency;

    public Engine(string model, double power)
    {
        this.model = model;
        this.power = power;
        this.efficiency = "n/a";
    }
}