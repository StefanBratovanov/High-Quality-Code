namespace AirConditionerTestingSystem.Interfaces
{
    public interface IAirConditioner
    {
        string Manufacturer { get; set; }

        string Model { get; set; }

        int Test();
    }
}
