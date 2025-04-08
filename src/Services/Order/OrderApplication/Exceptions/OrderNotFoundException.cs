using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Exceptions;

namespace OrderApplication.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid Id) : base("Order",Id)
        {
        }
    }
}
