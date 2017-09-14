public class MachineGun : Ammunition
{
    private const double WeightConst = 10.6d;

    public MachineGun(string name)
        : base(name, WeightConst)
    {
    }
}