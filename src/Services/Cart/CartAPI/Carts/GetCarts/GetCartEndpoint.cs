



namespace CartAPI.Carts.GetCarts
{
    public record GetCartResponse(ShoppingCart Cart);
    public class GetCartEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/cart/{username}",async (string userName,ISender sender) => {
                var result = await sender.Send(new GetCartQuery(userName));
                var response = result.Adapt<GetCartResponse>();
                return Results.Ok(response);
            });
        }
    }
}
