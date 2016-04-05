using AirConditionerTestingSystem.UserInterface;

namespace AirConditionerTestingSystem.Core
{
    using System;
    using Interfaces;
    using Models;

    public class AirConditionerTestingSystemSystemEngine : IAirConditionerTestingSystemEngine
    {
        private IController controller;
        private IUserInterface userInterface;

        public AirConditionerTestingSystemSystemEngine()
        {
            this.controller = new Controller();
            this.userInterface = new ConsoleUserInterface();
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = this.userInterface.ReadLine();
                if (string.IsNullOrWhiteSpace(inputLine) || string.IsNullOrEmpty(inputLine))
                {
                    break;
                }

                inputLine = inputLine.Trim();
                try
                {
                    var command = new Command(inputLine);
                    this.controller.ProcessCommand(command);
                }
                catch (InvalidOperationException ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
            }
        }
    }
}
