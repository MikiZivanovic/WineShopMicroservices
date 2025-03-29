
namespace CatalogAPI.Variety.GetVariety
{
    public class GetVarietiesEndpoint : ICarterModule
    {
        public record GetVarietiesResponse(IEnumerable<Models.Variety> Varieties);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/varieties",async (ISender sender) => {

                var result = await sender.Send(new GetVarietiesQuery());

                var response = result.Adapt<GetVarietiesResponse>();

                return Results.Ok(response);
            });
        }
    }
}
