using System;

public class Calculation
{
    private static double planckConst;
    private static double pi;

    static Calculation()
    {
        planckConst = 6.62606896e-34;
        pi = 3.14159;
    }

    public static double PlanckConst
    {
        get { return planckConst; }
    }

    public static double Pi
    {
        get { return pi; }
    }

    public static void ReturnReducedPlanckConst()
    {
        Console.WriteLine(planckConst / (2 * pi));
    }
}