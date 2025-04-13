using CartAPI.Dtos;

namespace CartAPI.Carts.CheckoutCart
{
    public record CheckoutCartRequest(CartCheckoutDto CheckoutDto);
    public record CheckoutCartResponse(bool IsSuccess);
    public class CheckoutCartEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("cart/checkout", async (CheckoutCartRequest request, ISender sender) => {

                var command = request.Adapt<CheckoutCartCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CheckoutCartResponse>();

                return Results.Ok(response);
            
            });
        }
    }
}
