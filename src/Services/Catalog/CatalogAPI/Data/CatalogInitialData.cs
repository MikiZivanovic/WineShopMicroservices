using System.Collections;
using System.Runtime.CompilerServices;
using Marten.Schema;

namespace CatalogAPI.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

           
            if (await session.Query<Style>().AnyAsync() ||
                await session.Query<Models.Variety>().AnyAsync() ||
                await session.Query<Wine>().AnyAsync())
            {
                return;
            }


            var styles = getStylesPreconfigured();
            var varieties = getVarietiesPreconfigured();
            var wines = getWinesPreconfigured(styles, varieties);

            
            foreach (var style in styles)
            {
                session.Store(style);
            }

            foreach (var variety in varieties)
            {
                session.Store(variety);
            }

            foreach (var wine in wines)
            {
                session.Store(wine);
            }

            await session.SaveChangesAsync();
        }

        private static List<Style> getStylesPreconfigured() => new List<Style>()
        {
            new Style() { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Crveno" },
            new Style() { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Crno" },
            new Style() { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Roze" },
            new Style() { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Belo" }
        };

        private static List<Models.Variety> getVarietiesPreconfigured() => new List<Models.Variety>()
        {
            new Models.Variety() { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Sardone" },
            new Models.Variety() { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Tamjanika" },
            new Models.Variety() { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "Merlo" },
            new Models.Variety() { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "Kabarnet Suvinjon" },
            new Models.Variety() { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), Name = "Pinot Noir" }
        };

        private static List<Wine> getWinesPreconfigured(List<Style> styles, List<Models.Variety> varieties) => new List<Wine>()
        {
            new Wine()
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "Cabernet Sauvignon Reserve",
                Description = "Intense flavor with notes of blackberry and oak.",
                Year = 2020,
                Price = 25.99,
                Image = "cabernet_sauvignon.jpg",
                Style = styles.First(s => s.Name == "Crveno"),
                Variety = varieties.First(v => v.Name == "Kabarnet Suvinjon")
            },
            new Wine()
            {
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Name = "Chardonnay Premium",
                Description = "Bright and crisp with a hint of citrus.",
                Year = 2019,
                Price = 18.50,
                Image = "chardonnay.jpg",
                Style = styles.First(s => s.Name == "Belo"),
                Variety = varieties.First(v => v.Name == "Sardone")
            },
            new Wine()
            {
                Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                Name = "Pinot Noir Elegance",
                Description = "Delicate and aromatic with a touch of spice.",
                Year = 2021,
                Price = 30.00,
                Image = "pinot_noir.jpg",
                Style = styles.First(s => s.Name == "Crveno"),
                Variety = varieties.First(v => v.Name == "Pinot Noir")
            },
            new Wine()
            {
                Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                Name = "Tamjanika Delight",
                Description = "Fruity and floral with a unique character.",
                Year = 2022,
                Price = 20.00,
                Image = "tamjanika.jpg",
                Style = styles.First(s => s.Name == "Belo"),
                Variety = varieties.First(v => v.Name == "Tamjanika")
            },
            new Wine()
            {
                Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                Name = "Merlot Velvet",
                Description = "Smooth and rich with notes of plum and chocolate.",
                Year = 2020,
                Price = 22.00,
                Image = "merlot.jpg",
                Style = styles.First(s => s.Name == "Crno"),
                Variety = varieties.First(v => v.Name == "Merlo")
            },
            new Wine()
            {
                Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                Name = "Rose Petal Harmony",
                Description = "Light and refreshing with a hint of strawberry.",
                Year = 2021,
                Price = 15.00,
                Image = "rose.jpg",
                Style = styles.First(s => s.Name == "Roze"),
                Variety = varieties.First(v => v.Name == "Tamjanika")
            },
            new Wine()
            {
                Id = Guid.Parse("11112222-3333-4444-5555-666677778888"),
                Name = "Black Label Blend",
                Description = "A special blend of fine varieties.",
                Year = 2018,
                Price = 40.00,
                Image = "black_label.jpg",
                Style = styles.First(s => s.Name == "Crno"),
                Variety = varieties.First(v => v.Name == "Kabarnet Suvinjon")
            },
            new Wine()
            {
                Id = Guid.Parse("99990000-aaaa-bbbb-cccc-ddddeeeeffff"),
                Name = "Golden Chardonnay",
                Description = "Rich and buttery with hints of vanilla.",
                Year = 2019,
                Price = 28.00,
                Image = "golden_chardonnay.jpg",
                Style = styles.First(s => s.Name == "Belo"),
                Variety = varieties.First(v => v.Name == "Sardone")
            }
        };
    }
}
