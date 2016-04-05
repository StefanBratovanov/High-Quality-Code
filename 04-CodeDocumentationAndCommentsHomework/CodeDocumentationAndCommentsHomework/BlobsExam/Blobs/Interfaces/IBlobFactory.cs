namespace Blobs.Interfaces
{
    using Blobs.Models.Interfaces;

    /// <summary>
    /// Produces blobs
    /// </summary>
    public interface IBlobFactory
    {
        /// <summary>
        /// Produces different types of blobs
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="damage"></param>
        /// <param name="blobType"></param>
        /// <param name="attackType"></param>
        /// <returns>new type Blob</returns>
        IBlob ProduceBlob(string name, int health, int damage, string blobType, string attackType);
    }
}
