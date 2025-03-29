using CartAPI.Carts.DeleteCarts;
using CartAPI.Carts.GetCarts;
using CartAPI.Carts.StoreCarts;

namespace CartAPI.Data
{
    public interface ICartRepository
    {
        Task<ShoppingCart> StoreCart(ShoppingCart cart, CancellationToken cancellationToken = default);
        Task<bool> DeleteCart(string userName, CancellationToken cancellationToken = default);
        Task<ShoppingCart> GetCart(string userName, CancellationToken cancellationToken = default);
    }
}
