public class Knife : Ammunition
{
    private const double WeightConst = 0.4d;

    public Knife(string name)
        : base(name, WeightConst)
    {
    }
}