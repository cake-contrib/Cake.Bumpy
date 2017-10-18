using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Bumpy
{
    /// <summary>
    /// Contains settings used by <see cref="BumpyRunner"/>.
    /// </summary>
    public sealed class BumpySettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the directory path in which Bumpy will operate.
        /// </summary>
        /// <value>A directory path.</value>
        public DirectoryPath Directory { get; set; }

        /// <summary>
        /// Gets or sets the file path to a Bumpy configuration file.
        /// </summary>
        /// <value>A Bumpy configuration file.</value>
        public FilePath Configuration { get; set; }

        /// <summary>
        /// Gets or sets the profile Bumpy will use.
        /// </summary>
        /// <value>A profile name.</value>
        public string Profile { get; set; }
    }
}
