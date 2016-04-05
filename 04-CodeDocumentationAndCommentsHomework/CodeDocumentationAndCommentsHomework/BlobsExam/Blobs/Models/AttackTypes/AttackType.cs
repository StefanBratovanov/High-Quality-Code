
namespace Blobs.Models.AttackTypes
{
    using Interfaces;

    public abstract class AttackType : IAttackType
    {
        protected AttackType(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public abstract void Hit(IBlob targetBlob);
    }
}
