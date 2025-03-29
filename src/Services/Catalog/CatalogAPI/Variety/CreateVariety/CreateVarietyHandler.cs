using BuildingBlocks.CQRS;
using CatalogAPI.Models;
using Marten;


namespace CatalogAPI.Variety.CreateVariety
{
    public record CreateVarietyCommand(string Name): ICommand<CreateVarietyResult> ;

    public record CreateVarietyResult(Guid Id);
    internal class CreateVarietyCommmandHandler(IDocumentSession session) : ICommandHandler<CreateVarietyCommand, CreateVarietyResult>
    {
        public async Task<CreateVarietyResult> Handle(CreateVarietyCommand command, CancellationToken cancellationToken)
        {

            var variety = new CatalogAPI.Models.Variety
            {
                Name = command.Name
            };

            session.Store(variety);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateVarietyResult(variety.Id);
        }
    }
}
