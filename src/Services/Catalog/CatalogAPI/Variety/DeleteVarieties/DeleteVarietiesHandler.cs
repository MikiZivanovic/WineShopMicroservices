using BuildingBlocks.CQRS;

namespace CatalogAPI.Variety.DeleteVarieties
{
    public record DeleteVarietiesCommand(Guid Id) : ICommand<DeleteVarietiesResult>;
    public record DeleteVarietiesResult(bool IsSuccess);
    internal class DeleteVarietiesCommandHandler(IDocumentSession session) : ICommandHandler<DeleteVarietiesCommand, DeleteVarietiesResult>
    {
        public async Task<DeleteVarietiesResult> Handle(DeleteVarietiesCommand command, CancellationToken cancellationToken)
        {
            session.Delete<Models.Variety>(command.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteVarietiesResult(true);
        }
    }
}
