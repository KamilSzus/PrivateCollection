using PrivateCollection.Enums;

namespace PrivateCollection.Models
{
    public class BoardGameGenre
    {
        public long BoardGameId { get; set; }
        public long GenereId  { get; set; }
        public required BoardGame BoardGame { get; set; }
        public required Genre Genre { get; set; }
    }
}
