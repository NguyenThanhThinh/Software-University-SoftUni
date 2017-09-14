using System.Collections.Generic;

public class Person
{
    private string name;
    private string bornDate;
    private List<PersonChildren> children;
    private List<PersonParents> parents;

    public Person()
    {
        this.Children = new List<PersonChildren>();
        this.Parents = new List<PersonParents>();
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

    public List<PersonChildren> Children
    {
        get { return children; }
        set { children = value; }
    }

    public List<PersonParents> Parents
    {
        get { return parents; }
        set { parents = value; }
    }
}