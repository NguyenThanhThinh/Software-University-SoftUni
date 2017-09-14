public class Car
{
    private string model;
    private double speed;

    public Car()
    {
        this.model = string.Empty;
    }

    public Car(string model, double speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public double Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}