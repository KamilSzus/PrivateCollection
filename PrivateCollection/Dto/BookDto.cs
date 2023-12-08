namespace PrivateCollection.Dto
{
    public record BookDto(
        string Name,
        List<string> Author,
        string Category,
        bool IsFinished);
}
