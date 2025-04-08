using Carter;
using Mapster;
using MediatR;
using OrderApplication.Dtos;
using OrderApplication.Orders.Queries.GetOrdesByCustomer;

namespace OrderAPI.Endpoints
{
    public class GetOrdersByCustomer : ICarterModule
    {
        public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sander) => {



                var result = await sander.Send(new GetOrdesByCustomerQuery(customerId));

                var response = result.Adapt<GetOrdersByCustomerResponse>();

                return Results.Ok(response);

            });
        }
    }

}
