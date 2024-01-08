namespace PrivateCollection.Models
{
    public class BoardGame
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string PublishingHouse { get; set; }
        public BoardGameStats? BoardGameStats { get; set; }
        public virtual ICollection<BoardGameGenre> BoardGameGenre { get; set; } = new List<BoardGameGenre>();

    }
}
