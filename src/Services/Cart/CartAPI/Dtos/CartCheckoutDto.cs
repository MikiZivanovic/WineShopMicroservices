using BuildingBlocksMessaging.Events.Models;

namespace CartAPI.Dtos
{
    public record CartCheckoutDto
    {
        public string UserName { get; set; } = default!;

        public Guid CustomerId { get; set; }
        public List<CartItemDTO> Items { get; set; } = new();

        public decimal TotalPrice { get; set; } = default!;

        public string CardName { get; set; } = default!;

        public string CardNumber { get; set; } = default!;

        public string Exparation { get; set; } = default!;

        public string CVV { get; set; } = default!;
    }
}
