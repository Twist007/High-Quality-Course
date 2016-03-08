namespace Capitalism.Interfaces
{
    /// <summary>
    /// Writes formatted output to the console
    /// </summary>
    public interface IWriter
    {
        void WriteLine(string output);
        void WriteLine(string format, params object[] args);
    }
}
