namespace CatalogAPI.Models
{
    public class Wine
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Year { get; set; }
        public double Price { get; set; }

        public string Image { get; set; } = default!;

        public Style Style { get; set; } = new Style();

        public Variety Variety { get; set; } = new Variety();
    }
}
