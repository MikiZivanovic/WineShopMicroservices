


using System.Text.Json;

namespace CartAPI.Data
{
    public class CachedCartRepository(ICartRepository repository,IDistributedCache cache) : ICartRepository
    {
        public async Task<bool> DeleteCart(string userName, CancellationToken cancellationToken = default)
        {
            await repository.DeleteCart(userName, cancellationToken);
            await cache.RemoveAsync(userName, cancellationToken);
            return true;
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

        public async  Task<ShoppingCart> StoreCart(ShoppingCart cart, CancellationToken cancellationToken = default)
        {
            await repository.StoreCart(cart,cancellationToken);
            await cache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart));
            return cart;
        }
    }
}
