using System;

public class OutputWriter : IOutputWriter
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}