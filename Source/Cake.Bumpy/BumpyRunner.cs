using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.IO.Arguments;
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
        /// Runs "bumpy list".
        /// </summary>
        public void List()
        {
            Run("list");
        }

        /// <summary>
        /// Runs "bumpy list" with additional settings.
        /// </summary>
        /// <param name="settings">The tool settings.</param>
        public void List(BumpySettings settings)
        {
            Run(settings, "list");
        }

        /// <summary>
        /// Runs "bumpy new".
        /// </summary>
        public void New()
        {
            Run("new");
        }

        /// <summary>
        /// Runs "bumpy increment [position]".
        /// </summary>
        /// <param name="position">The position.</param>
        public void Increment(int position)
        {
            Run("increment", $"{position}");
        }

        /// <summary>
        /// Runs "bumpy increment [position]" with additional settings.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="settings">The tool settings.</param>
        public void Increment(int position, BumpySettings settings)
        {
            Run(settings, "increment", $"{position}");
        }

        /// <summary>
        /// Runs "bumpy incrementonly [position]" with additional settings.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="settings">The tool settings.</param>
        public void IncrementOnly(int position, BumpySettings settings)
        {
            Run(settings, "incrementonly", $"{position}");
        }

        /// <summary>
        /// Runs "bumpy incrementonly [position]".
        /// </summary>
        /// <param name="position">The position.</param>
        public void IncrementOnly(int position)
        {
            Run("incrementonly", $"{position}");
        }

        /// <summary>
        /// Runs "bumpy write [version]".
        /// </summary>
        /// <param name="version">The version.</param>
        public void Write(string version)
        {
            Run("write", version);
        }

        /// <summary>
        /// Runs "bumpy write [version] with additional settings".
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="settings">The tool settings.</param>
        public void Write(string version, BumpySettings settings)
        {
            Run(settings, "write", version);
        }

        /// <summary>
        /// Runs "bumpy assign [position] [number]".
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="number">The number.</param>
        public void Assign(int position, int number)
        {
            Run("assign", $"{position}", $"{number}");
        }

        /// <summary>
        /// Runs "bumpy assign [position] [number]" with additional settings.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="number">The number.</param>
        /// <param name="settings">The tool settings.</param>
        public void Assign(int position, int number, BumpySettings settings)
        {
            Run(settings, "assign", $"{position}", $"{number}");
        }

        /// <summary>
        /// Runs "bumpy label [text]".
        /// </summary>
        /// <param name="text">The postfix version text.</param>
        public void Label(string text)
        {
            Run("label", text);
        }

        /// <summary>
        /// Runs "bumpy label [text]" with additional settings.
        /// </summary>
        /// <param name="text">The postfix version text.</param>
        /// <param name="settings">The tool settings.</param>
        public void Label(string text, BumpySettings settings)
        {
            Run(settings, "label", text);
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
            Run(new BumpySettings(), arguments);
        }

        private void Run(BumpySettings settings, params string[] arguments)
        {
            var builder = new ProcessArgumentBuilder();

            foreach (var argument in arguments)
            {
                builder.Append(argument);
            }

            AppendOption(builder, "-d", settings.Directory?.FullPath);
            AppendOption(builder, "-c", settings.Configuration?.FullPath);
            AppendOption(builder, "-p", settings.Profile);

            Run(settings, builder);
        }

        private void AppendOption(ProcessArgumentBuilder builder, string option, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                builder.Append(option);
                builder.Append(new QuotedArgument(new TextArgument(value)).Render());
            }
        }
    }
}
