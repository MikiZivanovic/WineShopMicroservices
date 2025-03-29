



namespace CartAPI.Data
{
    public class CartRepository(IDocumentSession session) : ICartRepository
    {

        public async Task<ShoppingCart> GetCart(string userName, CancellationToken cancellationToken = default)
        {
            var cart = await session.LoadAsync<ShoppingCart>(userName,cancellationToken);
            return cart == null ? throw new CartNotFoundException(userName) : cart;
        }

        public async Task<ShoppingCart> StoreCart(ShoppingCart cart, CancellationToken cancellationToken = default)
        {
            session.Store(cart);
            await session.SaveChangesAsync(cancellationToken);
            return cart;
        }
        public async Task<bool> DeleteCart(string userName, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCart>(userName);
            await session.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
