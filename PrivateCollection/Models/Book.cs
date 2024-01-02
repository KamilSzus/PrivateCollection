namespace PrivateCollection.Models
{
    public class Book
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public required List<string> Authors { get; set; }
        public bool IsFinished { get; set; }
        public TimeSpan? ReadTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
