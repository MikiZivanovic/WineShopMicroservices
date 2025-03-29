
using CatalogAPI.Variety.DeleteVarieties;

namespace CatalogAPI.Styles.DeleteStyles
{
    public record DeleteStyleResponse(bool IsSuccess);
    public class DeleteStylesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("styles/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteStylesCommand(Id));
                var response = result.Adapt<DeleteStyleResponse>();

                return Results.Ok(response);
            });
        }
    }
}
