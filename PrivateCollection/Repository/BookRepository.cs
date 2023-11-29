using Microsoft.EntityFrameworkCore;
using PrivateCollection.Data;
using PrivateCollection.Interfaces;
using PrivateCollection.Models;

namespace PrivateCollection.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly PrivateCollectionContext Context;

        public BookRepository(PrivateCollectionContext context)
        {
            this.Context = context;
        }

        public async Task<ICollection<Book>> GetBooks()
        {
            return await this.Context.Books.OrderBy(b => b.Title).ToListAsync();
        }
    }
}
