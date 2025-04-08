using Carter;
using Mapster;
using MediatR;
using OrderApplication.Dtos;
using OrderApplication.Orders.Commands.CreateOrder;

namespace OrderAPI.Endpoints
{
    public class CreateOrder : ICarterModule
    {   public record CreateOrderRequest(OrderDto Order);
        public record CreateOrderResponse(Guid Id);
        
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async (CreateOrderRequest request, ISender sander) => {

                var command = request.Adapt<CreateOrderCommand>();

                var result = await sander.Send(command);

                var response = result.Adapt<CreateOrderResponse>();

                return Results.Created($"/orders/{response.Id}", response);

            });
        }

        
        
    }
}
