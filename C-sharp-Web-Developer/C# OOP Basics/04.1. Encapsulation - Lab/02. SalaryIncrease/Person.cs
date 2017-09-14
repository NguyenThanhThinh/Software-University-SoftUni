public class Person
{
    private string firstName;
    private string secondName;
    private int age;
    private double salary;

    public Person(string firstName, string secondName, int age, double salary)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.Age = age;
        this.Salary = salary;
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
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
        return $"{this.FirstName} {this.SecondName} get {this.Salary:F2} leva";
    }

    public void IncreaseSalary(double bonus)
    {
        if (age < 30)
        {
            this.Salary += this.Salary * (bonus / 2) / 100;
        }
        else
        {
            this.Salary += this.Salary * bonus / 100;
        }
    }
}