public abstract class Ammunition : IAmmunition
{
    private string name;
    private double weight;
    private double wearLevel;

    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = this.Weight * 100;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public double Weight
    {
        get { return this.weight; }
        protected set { this.weight = value; }
    }

    public double WearLevel
    {
        get { return this.wearLevel; }
        protected set { this.wearLevel = value; }
    }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}