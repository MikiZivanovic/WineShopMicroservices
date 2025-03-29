using BuildingBlocks.CQRS;
using CatalogAPI.Variety.GetVariety;

namespace CatalogAPI.Styles.GetStyles
{
    public record GetStylesQuery() : IQuery<GetStylesResult>;
    public record GetStylesResult(IEnumerable<Models.Style> Styles);
    public class GetStylesQueryHandler(IDocumentSession session) : IQueryHandler<GetStylesQuery, GetStylesResult>
    {
        public async Task<GetStylesResult> Handle(GetStylesQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query<Models.Style>().ToListAsync(cancellationToken);

            return new GetStylesResult(result);
        }
    }
}
