namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Reader for input.
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// Read line of input.
        /// </summary>
        /// <returns>String of next read line.</returns>
        string ReadNextLine();
    }
}
