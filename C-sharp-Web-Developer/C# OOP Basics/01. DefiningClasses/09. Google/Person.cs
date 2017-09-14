using System.Collections.Generic;

public class Person
{
    private string name;
    private Company company;
    private List<Pokemon> pokemon;
    private List<Parents> parents;
    private List<Children> children;
    private Car car;

    public Person(string name)
    {
        this.name = name;
        this.pokemon = new List<Pokemon>();
        this.parents = new List<Parents>();
        this.children = new List<Children>();
        this.company = new Company();
        this.car = new Car();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Company Company
    {
        get { return company; }
        set { company = value; }
    }

    public List<Pokemon> Pokemon
    {
        get { return pokemon; }
        set { pokemon = value; }
    }

    public List<Parents> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public List<Children> Children
    {
        get { return children; }
        set { children = value; }
    }

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }
}