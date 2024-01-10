using PrivateCollection.Models;

namespace PrivateCollection.Dto
{
    public class BoardGameDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string PublishingHouse { get; set; }
        public List<string> Category { get; set; } = new List<string>();

        public BoardGameStats? Stats { get; set; }
    }
}