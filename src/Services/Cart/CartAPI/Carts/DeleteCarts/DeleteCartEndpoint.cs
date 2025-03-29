
namespace CartAPI.Carts.DeleteCarts
{
    public record DeleteCartResponse(bool IsSuccess);
    public class DeleteCartEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/cart/{userName}", async (string userName,ISender sender) =>
            {
                var result = await sender.Send(new DeleteCartCommand(userName));
                var response = result.Adapt<DeleteCartResponse>();

                return Results.Ok(response);
            });
        }
    }
}
