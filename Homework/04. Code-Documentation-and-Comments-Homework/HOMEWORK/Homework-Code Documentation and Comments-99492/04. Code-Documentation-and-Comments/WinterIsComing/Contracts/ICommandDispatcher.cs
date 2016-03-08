namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Handle commands. 
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Gets or set Engine.
        /// </summary>
        IEngine Engine { get; set; }

        /// <summary>
        /// Dispatches the appropriate command depending on given input.
        /// </summary>
        /// <param name="commandArgs">Given input</param>
        void DispatchCommand(string[] commandArgs);

        /// <summary>
        /// Predefine all acceptable commands.
        /// </summary>
        void SeedCommands();
    }
}