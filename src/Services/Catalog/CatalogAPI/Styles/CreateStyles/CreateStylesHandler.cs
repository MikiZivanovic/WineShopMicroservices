using BuildingBlocks.CQRS;

namespace CatalogAPI.Styles.CreateStyles
{
    public record CreateStyleCommand(string Name) : ICommand<CreateStyleResult>;

    public record CreateStyleResult(Guid Id);
    internal class CreateStyleCommandHandler(IDocumentSession session) : ICommandHandler<CreateStyleCommand, CreateStyleResult>
    {
        public async Task<CreateStyleResult> Handle(CreateStyleCommand command, CancellationToken cancellationToken)
        {
            var style = new CatalogAPI.Models.Style
            {
                Name = command.Name
            };

            session.Store(style);
            await session.SaveChangesAsync(cancellationToken);
            
            return new CreateStyleResult(style.Id);
        }
    }
}
