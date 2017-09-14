using System;
using System.Text;

public abstract class Provider : IProvider
{
    private const double DurabilityConst = 1000d;
    private const double DurabilityLost = 100d;

    private int id;
    private double durability;
    private double energyOutput;

    protected Provider(int id, double durability, double energyOutput)
    {
        this.id = id;
        this.durability = durability;
        this.energyOutput = energyOutput;
    }

    public int ID
    {
        get { return this.id; }
    }

    public double Durability
    {
        get { return this.durability; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.durability = value;
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.durability -= DurabilityLost;
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set { this.energyOutput = value; }

    }

    public void Repair(double val)
    {
        this.durability += val;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name}")
            .AppendLine($"Durability: {this.Durability}");
        return sb.ToString();
    }
}