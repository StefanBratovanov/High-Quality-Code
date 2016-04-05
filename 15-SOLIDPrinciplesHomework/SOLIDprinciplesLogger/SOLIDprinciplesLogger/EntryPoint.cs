namespace SOLIDprinciplesLogger
{
    using Interfaces;
    using Models;
    using Models.Appenders;
    using Models.Layouts;
    using Models.Loggers;

    public class EntryPoint
    {
        static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            var fileAppender = new FileAppender(simpleLayout)
            {
                File = "../../logResult.txt"
            };

            var logger = new Logger(consoleAppender, fileAppender);

            logger.Error("Error : Index out of bounds.");
            logger.Info("Database modified.");
            logger.Warn("Warning - script not found.");

            var xmlLayout = new XmlLayout();

            consoleAppender = new ConsoleAppender(xmlLayout);
            logger = new Logger(consoleAppender);
            logger.Fatal("Windows blue :)");
            logger.Critical("Server down");

            consoleAppender = new ConsoleAppender(simpleLayout)
            {
                ReportLevel = ReportLevel.Error
            };
            logger = new Logger(consoleAppender);


            logger.Info("Process finished.");
            logger.Warn("Warning: CPU temperature too high");
            logger.Error("No Internet connection");
            logger.Critical("Windows blue :)");
            logger.Fatal("Server down");
        }
    }
}
