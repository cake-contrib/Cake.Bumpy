using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Bumpy
{
    /// <summary>
    /// The Bumpy runner.
    /// </summary>
    public class BumpyRunner : Tool<BumpySettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BumpyRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator</param>
        public BumpyRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs "bumpy -l".
        /// </summary>
        public void List()
        {
            Run("-l");
        }

        /// <summary>
        /// Runs "bumpy [profile] -l".
        /// </summary>
        /// <param name="profile">The profile.</param>
        public void List(string profile)
        {
            Run(profile, "-l");
        }

        /// <summary>
        /// Runs "bumpy -p".
        /// </summary>
        public void Profiles()
        {
            Run("-p");
        }

        /// <summary>
        /// Runs "bumpy -c".
        /// </summary>
        public void CreateConfiguration()
        {
            Run("-c");
        }

        /// <summary>
        /// Runs "bumpy -i [position]".
        /// </summary>
        /// <param name="position">The position.</param>
        public void Increment(int position)
        {
            Run("-i", $"{position}");
        }

        /// <summary>
        /// Runs "bumpy [profile] -i [position]".
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <param name="position">The position.</param>
        public void Increment(string profile, int position)
        {
            Run(profile, "-i", $"{position}");
        }

        /// <summary>
        /// Runs "bumpy -w [version]".
        /// </summary>
        /// <param name="version">The version.</param>
        public void Write(string version)
        {
            Run("-w", version);
        }

        /// <summary>
        /// Runs "bumpy [profile] -w [version]".
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <param name="version">The version.</param>
        public void Write(string profile, string version)
        {
            Run(profile, "-w", version);
        }

        /// <summary>
        /// Runs "bumpy -a [position] [number]".
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="number">The number.</param>
        public void Assign(int position, int number)
        {
            Run("-a", $"{position}", $"{number}");
        }

        /// <summary>
        /// Runs "bumpy [profile] -a [position] [number]".
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <param name="position">The position.</param>
        /// <param name="number">The number.</param>
        public void Assign(string profile, int position, int number)
        {
            Run(profile, "-a", $"{position}", $"{number}");
        }

        /// <summary>
        /// Gets the name of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "bumpy.exe" };
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "Bumpy";
        }

        private void Run(params string[] arguments)
        {
            var settings = new BumpySettings();
            var builder = new ProcessArgumentBuilder();

            foreach (var argument in arguments)
            {
                builder.Append(argument);
            }

            Run(settings, builder);
        }
    }
}
