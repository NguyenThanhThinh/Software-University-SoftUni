public class Cylinder
{
    private double radius;
    private double height;

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public Cylinder(double radius, double height)
    {
        this.radius = radius;
        this.height = height;
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }
}