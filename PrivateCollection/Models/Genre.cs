namespace PrivateCollection.Models
{
    public class Genre
    {
        public long Id { get; set; }
        public required string GenreType { get; set; }

        public ICollection<BoardGameGenre>? BoardGameGenres { get; set; }
        public ICollection<BookGenre>? BookGenres { get; set; }
    }
}
