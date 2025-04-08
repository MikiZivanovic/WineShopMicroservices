using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderDomain.Models;

namespace OrderApplication.Data
{
    public interface IApplicationDbContext
    {
         DbSet<Customer> Customers { get; }

         DbSet<Wine> Wines { get; }

         DbSet<Order> Orders { get; }

         DbSet<OrderItem> OrderItems { get; }

         Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
