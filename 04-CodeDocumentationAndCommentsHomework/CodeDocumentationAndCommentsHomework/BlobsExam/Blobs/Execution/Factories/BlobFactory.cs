



namespace Blobs.Execution.Factories
{
    using System;
    using Blobs.Models.Blobs;
    using Blobs.Interfaces;
    using Blobs.Models.Interfaces;

    public class BlobFactory : IBlobFactory
    {
        public IBlob ProduceBlob(string name, int health, int damage, string blobType, string attackType)
        {
            switch (blobType)
            {
                case "Inflated":
                    return new Inflated(name, health, damage, blobType, attackType);
                case "Aggressive":
                    return new Aggressive(name, health, damage, blobType, attackType);
                default:
                    throw new ArgumentException("invalid blob behavior");
            }
        }
    }
}
