public class Gun : Ammunition
{
    private const double WeightConst = 1.4d;

    public Gun(string name)
        : base(name, WeightConst)
    {
    }
}