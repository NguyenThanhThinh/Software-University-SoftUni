public class Student
{
    private string name;
    private static int counter;

    public Student(string name)
    {
        this.name = name;
        counter += 1;
    }

    static Student()
    {
        counter = 0;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public static int Counter
    {
        get { return counter; }
        set { counter = value; }
    }
}