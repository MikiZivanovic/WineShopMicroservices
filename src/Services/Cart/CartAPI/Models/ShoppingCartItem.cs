namespace CartAPI.Models
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; } = default!;

        public double Price { get; set; } = default!;

        public Guid WineId { get; set; } = default!;

        public string WineName { get; set; } = default!;
    }
}
