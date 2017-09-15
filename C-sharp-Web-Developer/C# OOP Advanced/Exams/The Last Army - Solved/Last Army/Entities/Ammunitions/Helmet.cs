public class Helmet : Ammunition
{
    private const double WeightConst = 2.3d;

    public Helmet(string name)
        : base(name, WeightConst)
    {
    }
}