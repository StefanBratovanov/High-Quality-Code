namespace AirConditionerTestingSystem.Interfaces
{
    using AirConditionerTestingSystem.Models;

    public interface IController
    {
        void ProcessCommand(Command command);
    }
}
