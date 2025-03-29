
using CatalogAPI.Variety.CreateVariety;

namespace CatalogAPI.Wines.CreateWines
{
    
    public record CreateWineRequest(string Name, string Description, int Year, double Price, string Image, Guid StyleId, Guid VarietyId);
    public record CreateWineResponse(Guid Id);
    public class CreateWinesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/wines", async (CreateWineRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateWineCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateWineResponse>();
                return Results.Created($"/wines/{response.Id}", response);

            });
        }
    }
}
