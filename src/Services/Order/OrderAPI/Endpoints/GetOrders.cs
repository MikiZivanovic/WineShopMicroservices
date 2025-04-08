using BuildingBlocks.Paginations;
using Carter;
using Mapster;
using MediatR;
using OrderApplication.Dtos;
using OrderApplication.Orders.Queries.GetOrders;

namespace OrderAPI.Endpoints
{
    public record PaginatedResponse(PaginatedResult<OrderDto> Orders);
    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginatedRequest request, ISender sander) => {



                var result = await sander.Send(new GetOrdersQuery(request));

                var response = result.Adapt<PaginatedResponse>();

                return Results.Ok(response);

            });
        }
    }
}
