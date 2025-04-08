using Carter;
using Mapster;
using MediatR;
using OrderApplication.Orders.Commands.DeleteOrder;

namespace OrderAPI.Endpoints
{
    public record DeleteOrderResponse(bool IsSuccess);
    public class DeleteOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/orders/{id}",async  (Guid id,ISender sander) => {

                

                var result = await sander.Send(new DeleteOrderCommand(id));

                var response = result.Adapt<DeleteOrderResponse>();

                return Results.Ok(response);

            });
        }
    }
}
