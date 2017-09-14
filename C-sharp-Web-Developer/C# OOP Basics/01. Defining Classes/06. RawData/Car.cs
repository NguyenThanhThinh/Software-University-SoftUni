public class Car
{
    public string model;
    public Cargo cargo;
    public Engine engine;
    public Tires tires;

    public Car(string model, Cargo cargo, Engine engine, Tires tires)
    {
        this.model = model;
        this.cargo = cargo;
        this.engine = engine;
        this.tires = tires;
    }
}