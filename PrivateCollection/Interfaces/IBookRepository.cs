using PrivateCollection.Models;

namespace PrivateCollection.Interfaces
{
    public interface IBookRepository
    {
        public Task<ICollection<Book>> GetBooksAsync();
        public Task<Book?> GetBookByIdAsync(int id);
        public Task<Book?> GetBookByTitleAsync(string title);
        public Task<bool> BookExistAsync(int id);
        public Task<ICollection<Book>> GetUnfishedBooksAsync();
    }
}
