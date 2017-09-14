public class Pokemon
{
    private string name;
    private string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }
}