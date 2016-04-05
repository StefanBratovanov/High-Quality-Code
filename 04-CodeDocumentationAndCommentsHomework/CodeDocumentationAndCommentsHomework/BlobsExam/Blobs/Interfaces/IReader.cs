namespace Blobs.Interfaces
{
    /// <summary>
    /// Cointains the reader of the input
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads the next line of the input
        /// </summary>
        /// <returns>The input as string</returns>
        string ReadLine();
    }
}
