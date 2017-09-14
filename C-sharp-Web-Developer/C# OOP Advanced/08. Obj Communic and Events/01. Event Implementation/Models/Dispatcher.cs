public delegate void NameChangeEventHandler(Dispatcher sender, NameChangeEventArgs args);

public class Dispatcher
{
    private string name;
    public event NameChangeEventHandler NameChange;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            OnNameChange(new NameChangeEventArgs(value));
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        if (NameChange != null)
        {
            NameChange(this, args);
        }
    }
}