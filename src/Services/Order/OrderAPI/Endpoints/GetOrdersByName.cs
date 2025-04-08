using Carter;
using Mapster;
using MediatR;
using OrderApplication.Dtos;
using OrderApplication.Orders.Queries.GetOrdersByName;

namespace OrderAPI.Endpoints
{
    public class GetOrdersByName : ICarterModule
    {
        public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{name}",async (string name, ISender sander) => {

                

                var result = await sander.Send(new GetOrdersByNameQuery(name));

                var response = result.Adapt<GetOrdersByNameResponse>();

                return Results.Ok(response);

            });
        }
    }
}
