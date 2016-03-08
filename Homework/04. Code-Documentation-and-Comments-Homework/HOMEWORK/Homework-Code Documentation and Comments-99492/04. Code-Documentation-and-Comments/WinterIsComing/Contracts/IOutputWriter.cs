namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Handle with outputs.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Gets input line and write it.
        /// </summary>
        /// <param name="line">Given input</param>
        void Write(string line);

        /// <summary>
        /// Flushes all lines.
        /// </summary>
        void Flush();
    }
}
