using BuildingBlocks.CQRS;

namespace CatalogAPI.Variety.UpdateVarieties
{
    public record UpdateVarietiesCommand(Guid Id,string Name): ICommand<UpdateVarietiesResult>;
    public record UpdateVarietiesResult(bool IsSuccess);
    internal class UpdateVarietiesHandler(IDocumentSession session) : ICommandHandler<UpdateVarietiesCommand, UpdateVarietiesResult>
    {
        public async Task<UpdateVarietiesResult> Handle(UpdateVarietiesCommand command, CancellationToken cancellationToken)
        {
            var variety = await session.LoadAsync<Models.Variety>(command.Id);

            if (variety is null) {
                throw new VarietyNotFoundException();
            }

            variety.Name  = command.Name;

            session.Update(variety);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateVarietiesResult(true);
        }
    }
}
