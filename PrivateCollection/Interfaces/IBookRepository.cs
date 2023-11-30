using PrivateCollection.Models;

namespace PrivateCollection.Interfaces
{
    public interface IBookRepository
    {
        public Task<ICollection<Book>> GetBooks();
        public Task<Book?> GetBookById(int id);
        public Task<Book?> GetBookByTitle(string title);
        public Task<bool> BookExist(int id);
        public Task<ICollection<Book>> GetUnFishedBooks();
    }
}
