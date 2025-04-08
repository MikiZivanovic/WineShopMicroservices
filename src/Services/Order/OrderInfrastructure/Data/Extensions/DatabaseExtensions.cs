using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderDomain.Models;
using OrderDomain.ValueObjects;

namespace OrderInfrastructure.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task InitializeDatabaseAsync(this WebApplication app) {

            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(ApplicationDbContext context) {

            await SeedCustomers(context);
            await SeedWines(context);
            await SeedOrders(context);
        }

        private static async Task SeedCustomers(ApplicationDbContext context)
        {
            if (!context.Customers.Any()) {
                await context.Customers.AddRangeAsync(InitialData.Customers);
                await context.SaveChangesAsync();
            }
           

        }
        private static async Task SeedWines(ApplicationDbContext context)
        {
            try
            {
                if (!context.Wines.Any())
                {
                   
                   
                    await context.Wines.AddRangeAsync(InitialData.Wines);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška u SeedWines: " + ex.Message);
                throw;
            }

        }
        private static async Task SeedOrders(ApplicationDbContext context)
        {
            if (!context.Orders.Any())
            {
                await context.Orders.AddRangeAsync(InitialData.Orders);
                await context.SaveChangesAsync();
            }


        }

    }
}
