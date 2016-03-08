namespace Capitalism.Interfaces
{
    /// <summary>
    /// Executes command
    /// </summary>
    public interface ICommandExecutor
    {
        string ExecuteCommand(ICommand command);
    }
}
