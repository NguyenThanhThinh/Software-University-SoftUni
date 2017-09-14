public class Animal
{
    private string name;
    private string breed;

    public Animal(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }
}