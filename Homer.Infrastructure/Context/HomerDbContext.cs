
using Homer.Domain.Common;
using Homer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homer.Infrastructure.Context
{
    /// <summary>
    /// Db context using SQLite
    /// </summary>
    public class HomerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual string DbPath { get; }

        /// <summary>
        /// Create an instance of DbContext
        /// </summary>
        public HomerDbContext()
        {
            DbPath = FilePath.DatabaseFilePath(FilePath.DefaultUserDataFolderPath);
            Database?.Migrate();
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
