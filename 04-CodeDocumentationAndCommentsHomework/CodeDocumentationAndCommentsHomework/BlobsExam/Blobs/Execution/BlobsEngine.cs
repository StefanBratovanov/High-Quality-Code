
namespace Blobs.Execution
{
    using Blobs.Interfaces;
    using Blobs.UserInterface;

    public class BlobsEngine : IEngine
    {
        private IUserInterface userInterface;
        private ICommandExecutor commandExecutor;

        public BlobsEngine()
        {
            this.userInterface = new ConsoleUserInterface();
            this.commandExecutor = new BlobsCommandExecutor();
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.userInterface.ReadLine();
                if (commandLine == "drop")
                {
                    break;
                }
                var command = new Command(commandLine);

                string commandResult = this.commandExecutor.ExecuteCommand(command);

                if (commandResult != null)
                {
                    this.userInterface.WriteLine(commandResult);
                }
            }
        }
    }
}
