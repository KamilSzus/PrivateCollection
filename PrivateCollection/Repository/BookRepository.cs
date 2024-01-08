using Microsoft.EntityFrameworkCore;
using PrivateCollection.Data;
using PrivateCollection.Dto;
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

        public async Task<bool> BookExistAsync(long id)
        {
            return await this.Context.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<Book> CreateBook(BookDto book)
        {
            var existingBook = await this.Context.Books.FindAsync(book.Id);

            if (existingBook is null)
            {
                var newBook = new Book
                {
                    Title = book.Title,
                    Authors = book.Authors,
                    IsFinished = book.IsFinished,
                    StartDate = book.StartDate,
                    EndDate = book.StartDate,
                    ReadTime = book.IsFinished ? book.EndDate - book.StartDate : null,

                };

                this.Context.Books.Add(newBook);
                this.Context.SaveChanges();

                return newBook;
            }

            existingBook.Title = book.Title;
            existingBook.Authors = book.Authors;
           // existingBook.BookGenres.Where(bg => bg.)

            this.Context.Update(book);
            this.Context.SaveChanges();

            return existingBook;
        }

        public async Task<Book?> GetBookByIdAsync(long id)
        {
            return await this.Context.Books.FindAsync(id);
        }

        public async Task<Book?> GetBookByTitleAsync(string title)
        {
            return await this.Context.Books.FirstOrDefaultAsync(b => b.Title == title);
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
