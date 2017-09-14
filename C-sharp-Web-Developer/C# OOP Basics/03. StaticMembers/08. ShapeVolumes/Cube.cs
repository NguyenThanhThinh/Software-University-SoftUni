public class Cube
{
    private double sideLenght;

    public Cube(double sideLenght)
    {
        this.sideLenght = sideLenght;
    }

    public double SideLenght
    {
        get { return sideLenght; }
        set { sideLenght = value; }
    }
}