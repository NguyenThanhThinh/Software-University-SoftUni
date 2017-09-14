using System;
using System.Collections.Generic;
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
            //switch (command)
            //{
            //    case "RegisterHarvester":
            //        var args = new List<string>(data.Skip(1).ToList());
            //        this.Manager.RegisterHarvester(args);
            //        break;
            //    case "RegisterProvider":
            //        args = new List<string>(data.Skip(1).ToList());
            //        this.Manager.RegisterProvider(args);
            //        break;
            //    case "Day":
            //        this.Manager.Day();
            //        break;
            //    case "Mode":
            //        args = new List<string>(data.Skip(1).ToList());
            //        this.Manager.Mode(args);
            //        break;
            //    case "Check":
            //        args = new List<string>(data.Skip(1).ToList());
            //        //Console.WriteLine(manager.Check(args));
            //        break;
            //    default:
            //        this.Manager.ShutDown();
            //        Environment.Exit(0);
            //        break;
            //}
        }
    }
}
