namespace PrivateCollection.Dto
{
    public class BookDto
    {
        public long Id { get; init; }
        public required string Title { get; init; }
        public required List<string> Authors { get; init; }
        public List<string>? Category { get; init; }
        public bool IsFinished { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }
}
