public abstract class Animal
{
    private string name;
    private double weight;
    private string type;
    private int foodEaten;

    protected Animal(string name, double weight, string type)
    {
        this.name = name;
        this.weight = weight;
        this.type = type;
    }

    protected string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    protected string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    protected double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    protected int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public abstract void MakeSound();
    public abstract void Eat(Food food);
}