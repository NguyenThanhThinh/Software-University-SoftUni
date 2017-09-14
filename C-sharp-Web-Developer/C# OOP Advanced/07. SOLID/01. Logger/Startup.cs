public class Startup
{
    public static void Main()
    {
        ILogger logger = CommontServices.ParseLoggerData();
        Controller controller = new Controller(logger);
        controller.StartReadingMessages();
    }
}