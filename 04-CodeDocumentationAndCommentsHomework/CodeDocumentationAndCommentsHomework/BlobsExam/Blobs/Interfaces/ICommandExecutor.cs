namespace Blobs.Interfaces
{
    /// <summary>
    /// Executes the command, depending on the input
    /// </summary>
    public interface ICommandExecutor
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="command"></param>
        /// <returns>command result</returns>
        string ExecuteCommand(ICommand command);
    }
}
