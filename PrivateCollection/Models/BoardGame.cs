namespace PrivateCollection.Models
{
    public class BoardGame
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int NumberOfGamesPlayed { get; set; } = 0;
        public required string PublishingHouse { get; set; }
        public TimeSpan? InGameTime { get; set; }
        public DateTime? LastGame {  get; set; }
        public int? GameCount { get; set; } = 0;
        public virtual ICollection<BoardGameGenre> BoardGameGenre { get; set; } = new List<BoardGameGenre>();

    }
}
