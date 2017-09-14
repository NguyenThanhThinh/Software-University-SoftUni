using System;
using System.Linq;

public class Dough
{
    private readonly string[] FlourTypesArray = { "white", "wholegrain" };

    private readonly string[] BakingTechniqueArray = {"crispy", "chewy", "homemade"};

    private string flourType;

    private string bakingTechnique;

    private double weight;

    public Dough()
    {
        
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    private string FlourType
    {
        set
        {
            if (!FlourTypesArray.Contains(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    private string BakingTechnique
    {
        set
        {
            if (!BakingTechniqueArray.Contains(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    private double Weight
    {
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public double CalculateCalories()
    {
        double caloryPerGram = 0d;

        if (flourType.ToLower().Equals("white"))
        {
            caloryPerGram = 2 * weight * 1.5 * GetBakingTechniqueValue(bakingTechnique);
        }
        else
        {
            caloryPerGram = 2 * weight * 1.0 * GetBakingTechniqueValue(bakingTechnique);
        }

        return caloryPerGram;
    }

    private double GetBakingTechniqueValue(string bakingTechnique1)
    {
        switch (bakingTechnique1.ToLower())
        {
            case "crispy":
                return 0.9d;
            case "chewy":
                return 1.1d;
            case "homemade":
                return 1.0d;
        }
        return 0d;
    }
}