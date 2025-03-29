
using CatalogAPI.Variety.GetVarietiesById;


namespace CatalogAPI.Styles.GetStylesById
{
 
    public class GetStylesByIdEndpoint:ICarterModule
    {
        public record GetStylesByIdResponse(Models.Style Style);
        
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("styles/{id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new GetStylesByIdQuery(Id));

                var response = result.Adapt<GetStylesByIdResponse>();

                return Results.Ok(response);
            });

        }

    }
}
