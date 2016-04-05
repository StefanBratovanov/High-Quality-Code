
using Blobs.Models.AttackTypes;

namespace Blobs.Models.Blobs
{
    using System;
    using Interfaces;

    public class Aggressive : Blob
    {
        public Aggressive(string name, int health, int damage, string blobType, string attackType)
            : base(name, health, damage, blobType, attackType)
        {
        }

        public override void Update()
        {
            if (this.InSpecialBahavior == true)
            {
               this.Damage -= 5;
            }
        }
    }
}
