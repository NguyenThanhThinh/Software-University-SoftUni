public class PersonParents
{
    private string name;
    private string bornDate;

    public PersonParents()
    {
        this.name = string.Empty;
        this.BornDate = string.Empty;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string BornDate
    {
        get { return bornDate; }
        set { bornDate = value; }
    }
}