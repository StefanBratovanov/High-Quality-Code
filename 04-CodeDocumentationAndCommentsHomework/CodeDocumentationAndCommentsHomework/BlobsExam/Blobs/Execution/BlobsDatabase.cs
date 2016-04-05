


namespace Blobs.Execution
{
    using System;
    using Blobs.Interfaces;
    using System.Collections.Generic;
    using Blobs.Models.Interfaces;

    public class BlobsDatabase : IDatabase
    {
        private readonly ICollection<IBlob> blobs = new List<IBlob>();

        public BlobsDatabase()
        {
            this.Blobs = new List<IBlob>();
        }

        public ICollection<IBlob> Blobs { get; private set; }

    }
}
