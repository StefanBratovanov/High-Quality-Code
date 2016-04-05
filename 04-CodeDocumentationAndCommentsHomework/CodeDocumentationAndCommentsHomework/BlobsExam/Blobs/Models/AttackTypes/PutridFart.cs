
namespace Blobs.Models.AttackTypes
{
    using System;
    using Interfaces;

    public class PutridFart : AttackType
    {
        public PutridFart(int damage) 
            : base(damage)
        {
        }

        public override void Hit(IBlob targetBlob)
        {
            targetBlob.Health -= this.Damage;
        }
    }
}
