using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reverseTeam;

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reverseTeam = new List<Person>();
    }

    public IReadOnlyCollection<Person> ReverseTeam
    {
        get { return reverseTeam; }
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return firstTeam; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            this.firstTeam.Add(person);
        }
        else
        {
            this.reverseTeam.Add(person);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First team have {this.firstTeam.Count} players");
        sb.AppendLine($"Reverse team have {this.reverseTeam.Count} players");

        return sb.ToString();
    }
}