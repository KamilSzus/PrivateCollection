namespace PrivateCollection.Dto
{
    public record BookDto(
        string name,
        List<string> author,
        string category,
        bool isFinished
        );
}
