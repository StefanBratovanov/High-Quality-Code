namespace Blobs.Models.Interfaces
{
    /// <summary>
    /// A unit, which can update itself 
    /// </summary>
    public interface IUpdateable
    {
        /// <summary>
        /// Updates the unit by some program logic
        /// </summary>
        void Update();
    }
}
