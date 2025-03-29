using BuildingBlocks.CQRS;
using CatalogAPI.Variety.GetVariety;
using Marten.Pagination;

namespace CatalogAPI.Wines.GetWines
{
    public record GetWinesQuery(int? PageNumber = 1, int? PageSize = 4) : IQuery<GetWinesResult>;
    public record GetWinesResult(IEnumerable<Models.Wine> Wines);
    internal class GetWinesQueryHandler(IDocumentSession session) : IQueryHandler<GetWinesQuery, GetWinesResult>
    {
        public async Task<GetWinesResult> Handle(GetWinesQuery query, CancellationToken cancellationToken)
        {
            var result = await session.Query<Models.Wine>().ToPagedListAsync(query.PageNumber ?? 1,query.PageSize ?? 4,cancellationToken);

            return new GetWinesResult(result);
        }
    }
}
