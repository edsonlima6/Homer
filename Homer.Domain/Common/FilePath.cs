using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Homer.Domain.Common
{
    /// <summary>
    /// Class containing file path constants.
    /// </summary>
    public static class FilePath
    {
        /// <summary>
        /// The default path to the user data folder.
        /// </summary>
        public static string DefaultUserDataFolderPath = Directory.GetCurrentDirectory();

        /// <summary>
        /// Gets the full path to the database file.
        /// </summary>
        /// <param name="baseDataDirectory">The base directory where all files used are stored.</param>
        /// <returns>The full path to the database file.</returns>
        public static string DatabaseFilePath(string baseDataDirectory) => GetDatabaseFilePath(baseDataDirectory);

        private static string GetDatabaseFilePath(string baseDataDirectory)
        {
            var basePath = Path.Combine(baseDataDirectory, "Database");
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            return Path.Combine(basePath, "skynet_user_session.db3");
        }
    }
}
