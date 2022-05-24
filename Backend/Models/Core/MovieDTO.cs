namespace BookMyShow.core.Models
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Language { get; set; } = null!;

        public string? ImagePath { get; set; }
    }
}
