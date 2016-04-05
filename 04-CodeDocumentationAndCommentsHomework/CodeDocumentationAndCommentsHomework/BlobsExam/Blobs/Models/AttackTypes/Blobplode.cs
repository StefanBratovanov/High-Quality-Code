
namespace Blobs.Models.AttackTypes
{
    using System;
    using Interfaces;

    public class Blobplode : AttackType
    {
        public Blobplode(int damage)
            : base(damage)
        {
        }

        public override void Hit(IBlob targetBlob)
        {
            targetBlob.Health -= 2 * this.Damage;
        }
    }
}
