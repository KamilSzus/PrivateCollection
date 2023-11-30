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

        public async Task<bool> BookExist(int id)
        {
            return await this.Context.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await this.Context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book?> GetBookByTitle(string title)
        {
            return await this.Context.Books.Where(b => b.Title == title).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Book>> GetBooks()
        {
            return await this.Context.Books.OrderBy(b => b.Title).ToListAsync();
        }

        public async Task<ICollection<Book>> GetUnFishedBooks()
        {
            return await this.Context.Books.Where(b => b.IsFinished == false).ToListAsync();
        }
    }
}
