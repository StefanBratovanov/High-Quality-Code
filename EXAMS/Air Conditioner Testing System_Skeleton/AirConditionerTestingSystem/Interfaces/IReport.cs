namespace AirConditionerTestingSystem.Interfaces
{
    /// <summary>
    /// Defines Report entity members
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Defines report manufacturer property
        /// </summary>
        string Manufacturer { get; set; }

        /// <summary>
        /// Defines report model property
        /// </summary>
        string Model { get; set; }

        /// <summary>
        /// Defines report mark property
        /// </summary>
        int Mark { get; set; }
    }
}
