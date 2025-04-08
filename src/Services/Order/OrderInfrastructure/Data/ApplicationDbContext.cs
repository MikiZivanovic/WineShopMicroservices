using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApplication.Data;
using OrderDomain.Models;

namespace OrderInfrastructure.Data
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Wine> Wines => Set<Wine>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderItem> OrderItems => Set<OrderItem>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }

}
