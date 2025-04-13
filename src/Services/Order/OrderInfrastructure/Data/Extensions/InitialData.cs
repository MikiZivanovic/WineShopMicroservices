using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using OrderDomain.Models;
using OrderDomain.ValueObjects;

namespace OrderInfrastructure.Data.Extensions
{
    public class InitialData
    {
        public static IEnumerable<Customer> Customers=> new List<Customer>() { 
            Customer.Create(CustomerId.Of(new Guid("7f8e5f3b-1f66-4a0a-8c9c-2fdb3a9d59fc")),"miki","miki23@gmail.com"),
             Customer.Create(CustomerId.Of(new Guid("3c0d9c01-4a9e-4f2b-81c5-74b2c4f04293")),"kimi","kimi23@gmail.com")
        };


        public static IEnumerable<Wine> Wines => new List<Wine>() {
            Wine.Create(WineId.Of(new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff")), "Rose Petal Harmony", 15),
            Wine.Create(WineId.Of(new Guid("11112222-3333-4444-5555-666677778888")), "Black Label Blend", 40),
            Wine.Create(WineId.Of(new Guid("99990000-aaaa-bbbb-cccc-ddddeeeeffff")), "Golden Chardonnay", 28),
            Wine.Create(WineId.Of(new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee")), "Merlot Velvet", 22),
            Wine.Create(WineId.Of(new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")), "Cabernet Sauvignon Reserve", 25.99m),
            Wine.Create(WineId.Of(new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")), "Chardonnay Premium", 18.50m),
            Wine.Create(WineId.Of(new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc")), "Pinot Noir Elegance", 30.00m),
            Wine.Create(WineId.Of(new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd")), "Tamjanika Delight", 20.00m),
            
        };

        public static IEnumerable<Order> Orders {
            
           get
           {

                var payment1 = Payment.Of("miki", "11111111", "04/29", "334");
                var payment2 = Payment.Of("kimi", "11111122", "07/29", "634");

                Order order1 = Order.Create(OrderId.Of(new Guid("5f3a879b-5c0f-4d68-9b3b-93256f5e72b3")), CustomerId.Of(new Guid("7f8e5f3b-1f66-4a0a-8c9c-2fdb3a9d59fc")), OrderName.Of("Order1"), payment1);
                order1.Add(WineId.Of(new Guid("5f3a879b-5c0f-4d68-9b3b-93256f5e72b8")), 3,45);
                
                Order order2 = Order.Create(OrderId.Of(new Guid("5f3a879b-5c0f-4d68-9b3b-93256f5e72b1")), CustomerId.Of(new Guid("3c0d9c01-4a9e-4f2b-81c5-74b2c4f04293")), OrderName.Of("Order2"), payment2);
                order2.Add(WineId.Of(new Guid("7392f0c1-0e8d-42c2-a9d4-8bda1c1ecf13")), 2, 44);
                return new  List<Order>(){order1,order2 };
            }
        }
    }
}
