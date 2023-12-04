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

        public async Task<bool> BookExistAsync(int id)
        {
            return await this.Context.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await this.Context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book?> GetBookByTitleAsync(string title)
        {
            return await this.Context.Books.Where(b => b.Title == title).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Book>> GetBooksAsync()
        {
            return await this.Context.Books.OrderBy(b => b.Title).ToListAsync();
        }

        public async Task<ICollection<Book>> GetUnfishedBooksAsync()
        {
            return await this.Context.Books.Where(b => b.IsFinished == false).ToListAsync();
        }
    }
}
