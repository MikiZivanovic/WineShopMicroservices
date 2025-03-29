
namespace CatalogAPI.Variety.UpdateVarieties
{
    public class UpdateVarietiesEndpoint : ICarterModule
    {
        public record UpdateVarietiesRequest(Guid Id,string Name);
        public record UpdateVarietiesResponse(bool IsSuccess);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/varieties", async (UpdateVarietiesRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateVarietiesCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateVarietiesResponse>();
                return Results.Ok(response);
            });
        }
    }
}
