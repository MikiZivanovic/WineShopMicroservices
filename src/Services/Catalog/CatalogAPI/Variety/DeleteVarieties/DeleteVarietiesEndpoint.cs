
namespace CatalogAPI.Variety.DeleteVarieties
{
    public record DeleteVarietyResponse(bool IsSuccess);
    public class DeleteVarietiesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("varieties/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteVarietiesCommand(Id));
                var response = result.Adapt<DeleteVarietyResponse>();

                return Results.Ok(response);
            });
        }
    }
}
