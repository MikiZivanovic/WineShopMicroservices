
namespace CatalogAPI.Variety.GetVarietiesById
{
    public class GetVarietiesByIdEndpoint : ICarterModule
    {
        public record GetVarietiesByIdResponse(Models.Variety Variety);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("varieties/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new GetVarietiesByIdQuery(Id));

                var response = result.Adapt<GetVarietiesByIdResponse>();

                return Results.Ok(response); 
            });
        }
    }
}
