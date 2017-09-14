using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Accounts = new List<BankAccount>();
    }

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.name = name;
        this.age = age;
        this.accounts = accounts;
    }

    public List<BankAccount> Accounts
    {
        get { return accounts; }
        set { accounts = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double GetBalance()
    {
        return accounts.Sum(s => s.Balance);
    }
}