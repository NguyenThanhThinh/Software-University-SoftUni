class Employee
{
    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email;
    public int age;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = "n/a";
        this.age = -1;
    }

    //public string Name => this.name;
    //public decimal Salary => this.salary;
    //public string Position => this.position;

    //// we may use this option or the option from above, like (Position, Salary and Name)
    //public string Department
    //{
    //    get { return this.department; }
    //}

    //public string Email
    //{
    //    get { return this.email; }
    //    set { this.email = Email; }
    //}
    //public int Age
    //{
    //    get { return this.age; }
    //    // we should implement set
    //}
}
