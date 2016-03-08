namespace WinterIsComing
{
    using Contracts;
    using Core;

    public class WinterIsComingMain
    {
        private const int MatrixRows = 5;
        private const int MatrixCols = 5;

        public static void Main()
        {
            IInputReader consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter
            {
                AutoFlush = true
            };

            IUnitContainer unitMatrix = new MatrixContainer(MatrixRows, MatrixCols);
            ICommandDispatcher commandDispatcher = new ExtendedCommandDispacher();
            IUnitEffector unitEffector = new UnitEffector();

            var engine = new Engine(
                unitMatrix,
                consoleReader, 
                consoleWriter, 
                commandDispatcher, 
                unitEffector);

            engine.Start();
        }
    }
}
