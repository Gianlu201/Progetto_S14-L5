namespace Progetto_S14_L5.Models
{
    public class ShoesModelView
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public string? MainImage { get; set; }
        public List<string> Images { get; set; } = [];
    }
}
