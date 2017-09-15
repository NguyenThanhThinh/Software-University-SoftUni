using System;
using System.Linq;

public class Engine : IEngine
{
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;
    private const string ShutDown = "Shutdown";

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine();
            var args = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string result = this.commandInterpreter.ProcessCommand(args);
            this.writer.WriteLine(result);

            if (input.Equals(ShutDown))
            {
                Environment.Exit(0);
            }
        }
    }
}