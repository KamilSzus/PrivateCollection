namespace PrivateCollection.Dto
{
    public class BookDto
    {
        public string Title { get; init; }
        public List<string> Authors { get; init; }
        public List<string> Category { get; init; }
        public bool IsFinished { get; init; }
    }
}
