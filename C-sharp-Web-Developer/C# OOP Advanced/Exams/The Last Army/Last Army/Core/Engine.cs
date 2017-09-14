using System.Reflection;
using System.Text;

public class Engine : IEngine
{
    private const string Stop = "Enough! Pull back!";

    private GameController gameController;
    private IReader consoleReader;
    private IWriter writeLine;

    public Engine(GameController gameController, IReader consoleReader, IWriter writeLine)
    {
        this.gameController = gameController;
        this.consoleReader = consoleReader;
        this.writeLine = writeLine;
    }

    public void Run()
    {
        var input = this.consoleReader.ReadLine();
        var result = new StringBuilder();

        while (!input.Equals(Stop))
        {
            try
            {
                this.gameController.ProcessCommand(input);
            }
            catch (TargetInvocationException arg)
            {
                result.AppendLine(arg.InnerException.InnerException.Message);
            }
            input = this.consoleReader.ReadLine();
        }

        result.Append(this.gameController.GenerateFinalResultStats());
        this.writeLine.WriteLine(result.ToString());
    }
}