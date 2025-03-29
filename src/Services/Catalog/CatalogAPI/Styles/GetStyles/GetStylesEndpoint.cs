
using CatalogAPI.Variety.GetVariety;
using static CatalogAPI.Variety.GetVariety.GetVarietiesEndpoint;

namespace CatalogAPI.Styles.GetStyles
{
    public record GetStylesResponse(IEnumerable<Models.Style> Styles);
    public class GetStylesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/styles", async (ISender sender) => {

                var result = await sender.Send(new GetStylesQuery());

                var response = result.Adapt<GetStylesResponse>();

                return Results.Ok(response);
            });
        }
    }
}
