
using CatalogAPI.Variety.DeleteVarieties;

namespace CatalogAPI.Wines.DeleteWines
{
    public record DeleteWineResponse(bool IsSuccess);
    public class DeleteWinesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("wines/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteWinesCommand(Id));
                var response = result.Adapt<DeleteWineResponse>();

                return Results.Ok(response);
            });
        }
    }
}
