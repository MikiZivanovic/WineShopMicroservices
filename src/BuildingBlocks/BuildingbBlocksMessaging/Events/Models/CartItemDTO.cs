using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocksMessaging.Events.Models
{
    public record CartItemDTO
    {
        public int Quantity { get; set; } = default!;

        public decimal Price { get; set; } = default!;

        public Guid WineId { get; set; } = default!;

        public string WineName { get; set; } = default!;
    }
}
