
namespace Blobs.Interfaces
{
    /// <summary>
    /// Handles the output of the game
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Displays the given output
        /// </summary>
        /// <param name="output">String to be displayed</param>
        void WriteLine(string output);

        /// <summary>
        /// Displays the given output, considesring the parameters given
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void WriteLine(string format, params object[] args);
    }
}
