public abstract class Mammal : Animal
{
    private string livingRegion;

    protected Mammal(string name, double weight, string type, string livingRegion) 
        : base(name, weight, type)
    {
        this.livingRegion = livingRegion;
    }

    protected string LivingRegion
    {
        get { return this.livingRegion; }
        set { this.livingRegion = value; }
    }

    public override string ToString()
    {
        return string.Format(
            $"{GetType().FullName}[{Name}, {Weight}, {livingRegion}, {FoodEaten}]");
    }
}