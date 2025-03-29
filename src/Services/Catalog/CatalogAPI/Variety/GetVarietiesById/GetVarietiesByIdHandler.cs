



using BuildingBlocks.CQRS;


namespace CatalogAPI.Variety.GetVarietiesById
{
    public record GetVarietiesByIdQuery(Guid Id) : IQuery<GetVarietiesByIdResult>;
    public record GetVarietiesByIdResult(Models.Variety Variety);
    internal class GetVarietiesByIdHandler(IDocumentSession session) : IQueryHandler<GetVarietiesByIdQuery, GetVarietiesByIdResult>
    {
        public async Task<GetVarietiesByIdResult> Handle(GetVarietiesByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await session.LoadAsync<Models.Variety>(query.Id,cancellationToken);

            if (result is null) {
                throw new VarietyNotFoundException();
            }

            return new GetVarietiesByIdResult(result);
        }
    }
}
