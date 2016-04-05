

using Blobs.Models.AttackTypes;

namespace Blobs.Models.Blobs
{
    using System;
    using Interfaces;

    public class Inflated : Blob
    {
        public Inflated(string name, int health, int damage, string blobType, string attackType)
            : base(name, health, damage, blobType, attackType)
        {
        }

        public override void Update()
        {
            if (this.InSpecialBahavior == true)
            {
                this.Health -= 10;
            }
        }

    }
}
