using PrivateCollection.Models;

namespace PrivateCollection.Interfaces
{
    public interface IBookRepository
    {
        public Task<ICollection<Book>> GetBooks();
    }
}
