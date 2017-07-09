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
        /// Runs "bumpy.exe -l" to list all versions.
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
        /// Runs "bumpy.exe [profile] -l" to list all versions of a profile.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="profile">The profile.</param>
        /// <example>
        /// <code>
        /// BumpyList("foo");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyList(this ICakeContext context, string profile)
        {
            CreateRunner(context).List(profile);
        }

        /// <summary>
        /// Runs "bumpy.exe -p" to list all the profiles.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// BumpyProfiles();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyProfiles(this ICakeContext context)
        {
            CreateRunner(context).Profiles();
        }

        /// <summary>
        /// Runs "bumpy.exe -c" to create a configuration file if one does not exist.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// BumpyCreateConfiguration();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyCreateConfiguration(this ICakeContext context)
        {
            CreateRunner(context).CreateConfiguration();
        }

        /// <summary>
        /// Runs "bumpy.exe -i [position]" to increment all versions at the given position by one.
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
        /// Runs "bumpy.exe [profile] -i [position]" to increment all versions of a profile at the given position by one.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="profile">The profile.</param>
        /// <param name="position">The position.</param>
        /// <example>
        /// <code>
        /// // e.g. 1.0.0.0 -> 1.1.0.0
        /// BumpyIncrement("foo", 2);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyIncrement(this ICakeContext context, string profile, int position)
        {
            CreateRunner(context).Increment(profile, position);
        }

        /// <summary>
        /// Runs "bumpy.exe -w [version]" to overwrite all versions.
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
        /// Runs "bumpy.exe [profile] -w [version]" to overwrite all versions of a profile.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="profile">The profile.</param>
        /// <param name="version">The version.</param>
        /// <example>
        /// <code>
        /// // e.g. 1.0.0.0 -> 2.10.0.0
        /// BumpyVersion("foo", "2.10.0.0");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyWrite(this ICakeContext context, string profile, string version)
        {
            CreateRunner(context).Write(profile, version);
        }

        /// <summary>
        /// Runs "bumpy.exe -a [position] [number]" to assign a given position with a given number for all versions.
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
        /// Runs "bumpy.exe [profile] -a [position] [number]" to assign a given position with a given number for all versions of a profile.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="profile">The profile.</param>
        /// <param name="position">The position.</param>
        /// <param name="number">The version number part.</param>
        /// <example>
        /// <code>
        /// // e.g. 1.0.0.0 -> 1.42.0.0
        /// BumpyAssign("foo", 2, 42);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void BumpyAssign(this ICakeContext context, string profile, int position, int number)
        {
            CreateRunner(context).Assign(profile, position, number);
        }

        private static BumpyRunner CreateRunner(ICakeContext context)
        {
            return new BumpyRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
        }
    }
}
