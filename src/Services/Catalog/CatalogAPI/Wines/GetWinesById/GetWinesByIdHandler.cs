

namespace CatalogAPI.Wines.GetWinesById
{
    public record GetWinesByIdQuery(Guid Id) : IQuery<GetWinesByIdResult>;
    public record GetWinesByIdResult(Models.Wine Wine);
    internal class GetWinesByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetWinesByIdQuery, GetWinesByIdResult>
    {
        public async Task<GetWinesByIdResult> Handle(GetWinesByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await session.LoadAsync<Models.Wine>(query.Id, cancellationToken);

            if (result is null)
            {
                throw new WineNotFoundException(query.Id);
            }

            return new GetWinesByIdResult(result);
        }
    }
}
