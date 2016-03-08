namespace _01.Logger
{
    using Models;

    public class MainLogger
    {
        public static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();

            var consoleAppender = new ConsoleAppender(simpleLayout);
            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.FilePath = "../../log.txt";

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("Error parsing JSON.");
            logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
            logger.Warn("Warning - missing files.");
        }
    }
}