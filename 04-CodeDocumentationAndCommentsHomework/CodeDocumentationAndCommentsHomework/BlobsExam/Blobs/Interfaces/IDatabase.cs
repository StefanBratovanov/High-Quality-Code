namespace Blobs.Interfaces
{
    using Blobs.Models.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// Database, containing the entities
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Returns all Blobs in the game
        /// </summary>
        ICollection<IBlob> Blobs { get; }
    }
}
