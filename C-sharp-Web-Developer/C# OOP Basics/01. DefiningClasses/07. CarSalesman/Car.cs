public class Car
{
    public string model;
    public Engine engine;
    public double weight;
    public string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.color = "n/a";
    }
}