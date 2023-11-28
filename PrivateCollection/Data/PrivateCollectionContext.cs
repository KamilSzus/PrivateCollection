using Microsoft.EntityFrameworkCore;
using PrivateCollection.Models;
using System.Reflection.Metadata;

namespace PrivateCollection.Data
{
    public class PrivateCollectionContext : DbContext
    {
        public PrivateCollectionContext(DbContextOptions<PrivateCollectionContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BoardGame> BoardsGames { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
