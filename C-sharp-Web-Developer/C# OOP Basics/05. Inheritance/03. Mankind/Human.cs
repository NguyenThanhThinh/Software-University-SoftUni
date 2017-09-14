using System;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get { return firstName; }

        set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: firstName");
            }
            else if (value.Length < 4) // may be if the above is true and this one is true should show 2 Exceptions???
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName"); // may be lenght should be < 4
            }
            firstName = value;
        }
    }

    public virtual string LastName
    {
        get { return lastName; }

        set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: lastName");
            }
            else if (value.Length <= 3) // may be if the above is true and this one is true should show 2 Exceptions???
            {
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName"); // may be lenght should be < 3
            }
            lastName = value;
        }
    }
}