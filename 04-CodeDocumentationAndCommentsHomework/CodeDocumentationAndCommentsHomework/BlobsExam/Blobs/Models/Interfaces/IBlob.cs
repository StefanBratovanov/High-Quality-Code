namespace Blobs.Models.Interfaces
{
    /// <summary>
    /// Blob unit
    /// </summary>
    public interface IBlob : IBehavior, IUpdateable
    {
        /// <summary>
        /// Gets blob's name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets blob's health
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// Gets blob's initial health
        /// </summary>
        int InitialHealth { get; set; }

        /// <summary>
        /// Gets blob's damage
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Gets or sets whether the blob is in special behavior
        /// </summary>
        bool InSpecialBahavior { get; set; }

        /// <summary>
        /// Produces attack of some type
        /// </summary>
        /// <param name="attackType">the attack type of the unit</param>
        /// <returns>new attack of some type</returns>
        IAttackType ProduceAttack(string attackType);

        /// <summary>
        /// The way that unit responds to attack of some type
        /// </summary>
        /// <param name="attackType"></param>
        void RespondToAttack(IAttackType attackType);
    }
}
