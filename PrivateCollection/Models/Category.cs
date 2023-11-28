using PrivateCollection.Enums;

namespace PrivateCollection.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required Genre Genre { get; set; }
    }
}
