using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Bumpy
{
    /// <summary>
    /// <para>Contains functionality related to the command line tool Bumpy.</para>
    /// <para>
    /// In order to use the commands for this addin, you will need to include the following in your build.cake file to download and reference from NuGet.org:
    /// <code>
    /// #tool Bumpy
    /// </code>
    /// In addition, you will need to include the following:
    /// <code>
    /// #addin Cake.Bumpy
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("Bumpy")]
    public static class BumpyAliases
    {
        /// <summary>
        /// Runs "bumpy.exe list" to list all versions.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// BumpyList();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyList(this ICakeContext context)
        {
            CreateRunner(context).List();
        }

        /// <summary>
        /// Runs "bumpy.exe list" to list all versions.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The tool settings.</param>
        /// <example>
        /// <code>
        /// BumpyList(new BumpySettings() { Profile = "my_profile" });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyList(this ICakeContext context, BumpySettings settings)
        {
            CreateRunner(context).List(settings);
        }

        /// <summary>
        /// Runs "bumpy.exe new" to create a new configuration file if one does not exist.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// BumpyNew();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyNew(this ICakeContext context)
        {
            CreateRunner(context).New();
        }

        /// <summary>
        /// Runs "bumpy.exe increment [position]" to increment all versions at the given position by one.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="position">The position.</param>
        /// <example>
        /// <code>
        /// // e.g. 1.0.0.0 -> 1.1.0.0
        /// BumpyIncrement(2);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyIncrement(this ICakeContext context, int position)
        {
            CreateRunner(context).Increment(position);
        }

        /// <summary>
        /// Runs "bumpy.exe increment [position]" to increment all versions at the given position by one.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="position">The position.</param>
        /// <param name="settings">The tool settings.</param>
        /// <example>
        /// <code>
        /// // e.g. 1.0.0.0 -> 1.1.0.0
        /// BumpyIncrement(2, new BumpySettings() { Profile = "my_profile" });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyIncrement(this ICakeContext context, int position, BumpySettings settings)
        {
            CreateRunner(context).Increment(position, settings);
        }

        /// <summary>
        /// Runs "bumpy.exe write [version]" to overwrite all versions.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="version">The version.</param>
        /// <example>
        /// <code>
        /// // e.g. 1.0.0.0 -> 2.10.0.0
        /// BumpyVersion("2.10.0.0");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyWrite(this ICakeContext context, string version)
        {
            CreateRunner(context).Write(version);
        }

        /// <summary>
        /// Runs "bumpy.exe write [version]" to overwrite all versions.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="version">The version.</param>
        /// <param name="settings">The tool settings.</param>
        /// <example>
        /// <code>
        /// // e.g. 1.0.0.0 -> 2.10.0.0
        /// BumpyVersion("2.10.0.0", new BumpySettings() { Profile = "my_profile" });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyWrite(this ICakeContext context, string version, BumpySettings settings)
        {
            CreateRunner(context).Write(version, settings);
        }

        /// <summary>
        /// Runs "bumpy.exe assign [position] [number]" to assign a given position with a given number for all versions.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="position">The position.</param>
        /// <param name="number">The version number part.</param>
        /// <example>
        /// <code>
        /// // e.g. 1.0.0.0 -> 1.42.0.0
        /// BumpyAssign(2, 42);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyAssign(this ICakeContext context, int position, int number)
        {
            CreateRunner(context).Assign(position, number);
        }

        /// <summary>
        /// Runs "bumpy.exe assign [position] [number]" to assign a given position with a given number for all versions.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="position">The position.</param>
        /// <param name="number">The version number part.</param>
        /// <param name="settings">The tool settings.</param>
        /// <example>
        /// <code>
        /// // e.g. 1.0.0.0 -> 1.42.0.0
        /// BumpyAssign(2, 42, new BumpySettings() { Profile = "my_profile" });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyAssign(this ICakeContext context, int position, int number, BumpySettings settings)
        {
            CreateRunner(context).Assign(position, number, settings);
        }

        private static BumpyRunner CreateRunner(ICakeContext context)
        {
            return new BumpyRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
        }
    }
}
