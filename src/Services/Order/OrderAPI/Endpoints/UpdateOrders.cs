using Carter;
using Mapster;
using MediatR;
using OrderApplication.Dtos;
using OrderApplication.Orders.Commands.UpdateOrder;
using static OrderAPI.Endpoints.CreateOrder;

namespace OrderAPI.Endpoints
{
    public record UpdateOrderRequest(OrderDto Order);
    public record UpdateOrderResponse(bool IsSuccess);
    public class UpdateOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPut("/orders",async (UpdateOrderRequest request, ISender sander) => {

                var command = request.Adapt<UpdateOrderCommand>();

                var result = await sander.Send(command);

                var response = result.Adapt<UpdateOrderResponse>();

                return Results.Ok(response);

            });
        }
    }
}
