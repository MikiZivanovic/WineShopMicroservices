
namespace CartAPI.Carts.StoreCarts
{
    public record StoreCartRequest(ShoppingCart ShoppingCart) : ICommand<StoreCartResponse>;
    public record StoreCartResponse(string UserName);
    public class StoreCartEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/cart", async (StoreCartRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreCartCommand>();
                var result = await sender.Send(command); 
                var response = result.Adapt<StoreCartResponse>();
                return Results.Created($"/cart/{response.UserName}",response);
            });
        }
    }
}
