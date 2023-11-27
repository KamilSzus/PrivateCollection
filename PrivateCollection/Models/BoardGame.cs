namespace PrivateCollection.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int NumberOfGamesPlayed { get; set; } = 0;

        public required string PublishingHouse { get; set; }

        public TimeSpan? InGameTime { get; set; }

        public DateTime? LastGame {  get; set; }
    }
}
