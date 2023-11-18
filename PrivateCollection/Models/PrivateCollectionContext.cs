using Microsoft.EntityFrameworkCore;

namespace PrivateCollection.Models
{
    public class PrivateCollectionContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        private string DbPath { get; }

        public PrivateCollectionContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "PrivateCollection.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
