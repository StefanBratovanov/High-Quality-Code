namespace Blobs.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Commands interface, each command has name and parameters
    /// </summary>
    public interface ICommand
    {
        string Name { get; set; }

        IList<string> Parameters { get; set; }

    }
}
