namespace Blobs.Models.Interfaces
{
    /// <summary>
    /// The attack type of the units
    /// </summary>
    public interface IAttackType
    {
        /// <summary>
        /// The damage of the unit
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Performs attack
        /// </summary>
        /// <param name="targetBlob">The blob that is attacked</param>
        void Hit(IBlob targetBlob);
    }
}
