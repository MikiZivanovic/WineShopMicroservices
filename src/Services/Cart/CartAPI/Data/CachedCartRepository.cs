


using System.Text.Json;

namespace CartAPI.Data
{
    public class CachedCartRepository(ICartRepository repository,IDistributedCache cache) : ICartRepository
    {
        public Task<bool> DeleteCart(string userName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ShoppingCart> GetCart(string userName, CancellationToken cancellationToken = default)
        {
            var cartCached = await cache.GetStringAsync(userName,cancellationToken);
            if (!string.IsNullOrEmpty(cartCached)) {
                return JsonSerializer.Deserialize<ShoppingCart>(cartCached);
            }
            var cart = await repository.GetCart(userName,cancellationToken);
            await cache.SetStringAsync(userName, JsonSerializer.Serialize(cart),cancellationToken);
            return cart;
        }

        public Task<ShoppingCart> StoreCart(ShoppingCart cart, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
