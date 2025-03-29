



namespace CatalogAPI.Wines.GetWinesById
{
    public class GetWinesByIdEndpoint : ICarterModule
    {
        public record GetWinesByIdResponse(Models.Wine Wine);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("wines/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new GetWinesByIdQuery(Id));

                var response = result.Adapt<GetWinesByIdResponse>();

                return Results.Ok(response);
            });
        }
    }
}
