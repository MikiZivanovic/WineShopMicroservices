using BuildingBlocks.CQRS;
using CatalogAPI.Variety.DeleteVarieties;

namespace CatalogAPI.Styles.DeleteStyles
{
    public record DeleteStylesCommand(Guid Id) : ICommand<DeleteStylesResult>;
    public record DeleteStylesResult(bool IsSuccess);
    internal class DeleteStylesCommandHandler(IDocumentSession session) : ICommandHandler<DeleteStylesCommand, DeleteStylesResult>
    {
        public async Task<DeleteStylesResult> Handle(DeleteStylesCommand command, CancellationToken cancellationToken)
        {
            session.Delete<Models.Style>(command.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteStylesResult(true);
        }
    }
}
