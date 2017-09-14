public class Rectangles
{
    private string id;
    private int width;
    private int height;
    private int corX;
    private int corY;

    public Rectangles(string id, int width, int height, int corX, int corY)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.corX = corX;
        this.corY = corY;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    public int CorX
    {
        get { return corX; }
        set { corX = value; }
    }

    public int CorY
    {
        get { return corY; }
        set { corY = value; }
    }
}