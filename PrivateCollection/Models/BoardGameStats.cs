namespace PrivateCollection.Models
{
    public class BoardGameStats
    {
        public long Id { get; set; }
        public long BoardGameId { get; set; }
        public int? GameCount { get; set; } = 0;
        public TimeSpan? InGameTime { get; set; }
        public DateTime? LastGame { get; set; }
        public int? NumberOfWinGame {  get; set; } //TO DO: separete to players
    }
}
