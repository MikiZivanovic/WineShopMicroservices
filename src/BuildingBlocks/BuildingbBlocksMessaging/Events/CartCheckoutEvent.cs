using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocksMessaging.Events.Models;

namespace BuildingBlocksMessaging.Events
{
    public record CartCheckoutEvent : IntegrationEvent
    {
        public string UserName { get; set; } = default!;

        public Guid CustomerId { get; set; }
        public List<CartItemDTO> Items { get; set; } = new();

        public decimal TotalPrice { get; set; } =default!;

        public string CardName { get; set; } = default!;

        public string CardNumber { get; set; } = default!;

        public string Exparation { get; set; } = default!;

        public string CVV { get; set; } = default!;

    }
}
