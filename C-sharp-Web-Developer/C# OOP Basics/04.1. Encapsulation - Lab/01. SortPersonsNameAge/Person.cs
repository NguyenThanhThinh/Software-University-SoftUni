public class Person
{
    private string firstName;
    private string secondName;
    private int age;

    public Person(string firstName, string secondName, int age)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.Age = age;
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public string SecondName
    {
        get { return secondName; }
        private set { secondName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        private set { firstName = value; }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.SecondName} is a {this.Age} year old";
    }
}