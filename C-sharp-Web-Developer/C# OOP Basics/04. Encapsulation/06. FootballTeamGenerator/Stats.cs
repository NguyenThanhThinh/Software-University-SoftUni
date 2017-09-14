using System;

public class Stats
{
    private const double lowLimit = 0;
    private const double highLimit = 100;

    public Stats(params double[] statsValues)
    {
        this.Endurance = statsValues[0];
        this.Sprint = statsValues[1];
        this.Dribble = statsValues[2];
        this.Passing = statsValues[3];
        this.Shooting = statsValues[4];
    }

    private double endurance;
    private double sprint;
    private double dribble;
    private double passing;
    private double shooting;

    public double Endurance
    {
        get { return endurance; }
        set
        {
            if (value < lowLimit || value > highLimit)
            {
                throw new ArgumentException($"Endurance should be between 0 and 100.");
            }
            endurance = value;
        }
    }

    public double Sprint
    {
        get { return sprint; }
        set
        {
            if (value < lowLimit || value > highLimit)
            {
                throw new ArgumentException($"Sprint should be between 0 and 100.");
            }
            sprint = value;
        }
    }

    public double Dribble
    {
        get { return dribble; }
        set
        {
            if (value < lowLimit || value > highLimit)
            {
                throw new ArgumentException($"Dribble should be between 0 and 100.");
            }
            dribble = value;
        }
    }

    public double Passing
    {
        get { return passing; }
        set
        {
            if (value < lowLimit || value > highLimit)
            {
                throw new ArgumentException($"Passing should be between 0 and 100.");
            }
            passing = value;
        }
    }

    public double Shooting
    {
        get { return shooting; }
        set
        {
            if (value < lowLimit || value > highLimit)
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }
            shooting = value;
        }
    }
}