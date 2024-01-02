using PrivateCollection.Enums;

namespace PrivateCollection.Models
{
    public class BookGenre
    {
        public long BookId { get; set; }
        public long GenereId  { get; set; }
        public required Book Book { get; set; }
        public required Genre Genre { get; set; }
    }
}
