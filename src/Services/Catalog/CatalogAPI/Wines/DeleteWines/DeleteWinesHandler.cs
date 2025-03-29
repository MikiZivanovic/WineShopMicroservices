using BuildingBlocks.CQRS;
using CatalogAPI.Variety.DeleteVarieties;

namespace CatalogAPI.Wines.DeleteWines
{
    public record DeleteWinesCommand(Guid Id) : ICommand<DeleteWinesResult>;
    public record DeleteWinesResult(bool IsSuccess);
    internal class DeleteWinesCommandHandler(IDocumentSession session) : ICommandHandler<DeleteWinesCommand, DeleteWinesResult>
    {
        public async Task<DeleteWinesResult> Handle(DeleteWinesCommand command, CancellationToken cancellationToken)
        {
            session.Delete<Models.Wine>(command.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteWinesResult(true);
        }
    }
}
