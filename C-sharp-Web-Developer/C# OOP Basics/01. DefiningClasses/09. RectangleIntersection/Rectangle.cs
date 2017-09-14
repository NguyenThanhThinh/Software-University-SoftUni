public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double horizontal;
    private double vertical;

    public double Vertical
    {
        get { return vertical; }
        set { vertical = value; }
    }

    public double Horizontal
    {
        get { return horizontal; }
        set { horizontal = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public bool CheckIfRectanglesIntersect(Rectangle second)
    {
        if (this.Horizontal + this.Width < second.Horizontal || second.horizontal + second.Width < this.horizontal
            || this.Vertical + this.Height < second.vertical || second.Vertical + second.Height < this.vertical)
        {
            return false;
        }

        return true;
    }
}