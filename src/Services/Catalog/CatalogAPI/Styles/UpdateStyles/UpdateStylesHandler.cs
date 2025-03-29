using BuildingBlocks.CQRS;
using CatalogAPI.Variety.UpdateVarieties;

namespace CatalogAPI.Styles.UpdateStyles
{
    public record UpdateStylesCommand(Guid Id, string Name) : ICommand<UpdateStylesResult>;
    public record UpdateStylesResult(bool IsSuccess);
    internal class UpdateStylesCommandHandler(IDocumentSession session) : ICommandHandler<UpdateStylesCommand, UpdateStylesResult>
    {
        public async Task<UpdateStylesResult> Handle(UpdateStylesCommand command, CancellationToken cancellationToken)
        {
            var style = await session.LoadAsync<Models.Style>(command.Id);

            if (style is null)
            {
                throw new StyleNotFoundException();
            }

            style.Name = command.Name;

            session.Update(style);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateStylesResult(true);
        }
    }
}
