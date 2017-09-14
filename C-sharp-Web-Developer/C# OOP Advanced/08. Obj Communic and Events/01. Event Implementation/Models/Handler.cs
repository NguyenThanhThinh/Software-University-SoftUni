using System;

public class Handler
{
    public void OnDispatcherNameChange(Dispatcher sender, NameChangeEventArgs args)
    {
        Console.WriteLine($"Dispatcher’s name changed to {args.Name}.");
    }
}