
using CatalogAPI.Variety.GetVariety;
using static CatalogAPI.Variety.GetVariety.GetVarietiesEndpoint;

namespace CatalogAPI.Wines.GetWines
{
    public class GetWinesEndpoint : ICarterModule
    {
        public record GetWinesRequest(int? PageNumber=1, int? PageSize=4 );
        public record GetWinesResponse(IEnumerable<Models.Wine> Wines);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/wines", async ([AsParameters] GetWinesRequest request,ISender sender) => {

                var query = request.Adapt<GetWinesQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetWinesResponse>();

                return Results.Ok(response);
            });
        }

    }
}
