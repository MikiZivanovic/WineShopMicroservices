using BuildingBlocks.CQRS;
using CatalogAPI.Variety.GetVarietiesById;

namespace CatalogAPI.Styles.GetStylesById
{
    public record GetStylesByIdQuery(Guid Id) : IQuery<GetStylesByIdResult>;
    public record GetStylesByIdResult(Models.Style Style);
    internal class GetStylesByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetStylesByIdQuery, GetStylesByIdResult>
    {
        public async Task<GetStylesByIdResult> Handle(GetStylesByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await session.LoadAsync<Models.Style>(query.Id, cancellationToken);

            if (result is null)
            {
                throw new StyleNotFoundException();
            }

            return new GetStylesByIdResult(result);
        }
    }
}
