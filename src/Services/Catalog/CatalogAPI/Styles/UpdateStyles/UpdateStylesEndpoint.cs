
using static CatalogAPI.Variety.UpdateVarieties.UpdateVarietiesEndpoint;

namespace CatalogAPI.Styles.UpdateStyles
{
    internal class UpdateStylesEndpoint : ICarterModule
    {
        public record UpdateStylesRequest(Guid Id, string Name);
        public record UpdateStylesResponse(bool IsSuccess);

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/styles", async (UpdateStylesRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateStylesCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateStylesResponse>();
                return Results.Ok(response);
            });
        }


    }
}
