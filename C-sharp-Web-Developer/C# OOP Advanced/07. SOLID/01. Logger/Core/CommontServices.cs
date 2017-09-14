using System;

public static class CommontServices
{
    public static ReportLevel ParseReportLevel(string levelAsString)
    {
        ReportLevel level;
        Enum.TryParse(levelAsString, true, out level);
        return level;
    }

    public static ILogger ParseLoggerData()
    {
        ILogger logger = new DefaultLogger();

        int numberOfAppenders = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfAppenders; i++)
        {
            string[] appenderTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string appenderType = appenderTokens[0];
            string appenderLayour = appenderTokens[1];
            ReportLevel level = ReportLevel.Info;

            if (appenderTokens.Length == 3)
            {
                string reportLevel = appenderTokens[2];
                level = CommontServices.ParseReportLevel(reportLevel);

            }

            ILayout layout;
            switch (appenderLayour)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid layour type.");
            }


            IAppender appender = null;
            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, level);
                    break;
                case "FileAppender":
                    appender = new FileAppender(layout, level);
                    break;
            }

            logger.RegisterAppender(appender);
        }

        return logger;
    }
}