public class PersonChildren
{
    private string name;
    private string bornDate;

    public PersonChildren()
    {
        this.name = string.Empty;
        this.bornDate = string.Empty;
    }

    public string BornDate
    {
        get { return bornDate; }
        set { bornDate = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}