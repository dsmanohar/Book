using System;
using System.Collections.Generic;

namespace BookMyShow.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Language { get; set; } = null!;
        public DateTime? ReleasedOn { get; set; }
        public string? Imagepath { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
