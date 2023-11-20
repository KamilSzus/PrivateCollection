using Microsoft.EntityFrameworkCore;

namespace PrivateCollection.Models
{
    public class PrivateCollectionContext : DbContext
    {
        public PrivateCollectionContext(DbContextOptions<PrivateCollectionContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

    }
}
