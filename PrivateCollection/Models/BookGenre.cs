using PrivateCollection.Enums;

namespace PrivateCollection.Models
{
    public class BookGenre
    {
        public long BookId { get; set; }
        public long GenereId  { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
