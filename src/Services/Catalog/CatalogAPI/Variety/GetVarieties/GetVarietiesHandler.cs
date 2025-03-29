using BuildingBlocks.CQRS;

namespace CatalogAPI.Variety.GetVariety
{
    public record GetVarietiesQuery() : IQuery<GetVarietiesResult>;
    public record GetVarietiesResult(IEnumerable<Models.Variety> Varieties);
    internal class GetVarietiesQueryHandler(IDocumentSession session) : IQueryHandler<GetVarietiesQuery, GetVarietiesResult>
    {
        public async Task<GetVarietiesResult> Handle(GetVarietiesQuery query, CancellationToken cancellationToken)
        {
            var result = await session.Query<Models.Variety>().ToListAsync(cancellationToken);
           
            return new GetVarietiesResult( result );
        }
    }
}
