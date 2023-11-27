﻿namespace PrivateCollection.Models
{
    public class Book
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public required List<string> Authors { get; set; }
        public string? Categories { get; set; }
        public bool IsFinished { get; set; }

        public TimeSpan? ReadTime { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
    }
}
