

namespace CatalogAPI.Variety.CreateVariety
{
    public record CreateVarietyRequest(string Name);
    public record CreateVarietyResponse(Guid Id);
    public class CreateVarietyEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/varieties", async (CreateVarietyRequest request, ISender sender) => 
            {
                var command = request.Adapt<CreateVarietyCommand>();
            
                var result = await sender.Send(command);

                var response = result.Adapt<CreateVarietyResponse>();
                return Results.Created($"/varieties/{response.Id}", response);
            
            });
            
        }
    }
}
