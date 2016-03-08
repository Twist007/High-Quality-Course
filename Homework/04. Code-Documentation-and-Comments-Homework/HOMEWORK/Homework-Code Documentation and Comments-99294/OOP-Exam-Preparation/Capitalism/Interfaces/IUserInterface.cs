namespace Capitalism.Interfaces
{
    /// <summary>
    /// Reads and writes input to the console
    /// </summary>
    public interface IUserInterface : IReader, IWriter
    {
        // This interface is empty because it only combines
        // IReader and IWriter and does not include
        // any new members
    }
}