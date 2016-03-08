namespace Capitalism.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Holds command name and parametars
    /// </summary>
    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
