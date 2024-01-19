using PrivateCollection.Dto;
using PrivateCollection.Models;

namespace PrivateCollection.Interfaces
{
    public interface IBookRepository
    {
        public Task<ICollection<Book>> GetBooksAsync();
        public Task<Book?> GetBookByIdAsync(long id);
        public Task<Book?> GetBookByTitleAsync(string title);
        public Task<bool> BookExistAsync(long id);
        public Task<ICollection<Book>> GetUnfishedBooksAsync();
        public Task<Book> CreateBookAsync(BookDto book);
        public Task<Book> DeleteBookAsync(long bookId);
        public Task<Book> FinishBookAsync(DateTime EndDate, string title);
    }
}
