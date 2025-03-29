
using CatalogAPI.Variety.CreateVariety;

namespace CatalogAPI.Styles.CreateStyles
{
    public class CreateStylesEndpoint : ICarterModule
    {
        public record CreateStyleRequest(string Name);
        public record CreateStyleResponse(Guid Id);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/styles", async (CreateStyleRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateStyleCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateStyleResponse>();

                return Results.Created($"/styles/{response.Id}", response);

            });
        }
    }
}
