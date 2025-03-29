using System.Data;

namespace CatalogAPI.Wines.CreateWines
{
    public record CreateWineCommand(string Name,string Description,int Year,double Price,string Image,Guid StyleId,Guid VarietyId) : ICommand<CreateWineResult>;

    public record CreateWineResult(Guid Id);

    public class CreateWineCommandValidator : AbstractValidator<CreateWineCommand>
    {
        public CreateWineCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Wine must have a name");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Wine must have a description");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Wine must have a image");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Wine price must be over 0");
        }
    }
    internal class CreateWinesCommandHandler(IDocumentSession session) : ICommandHandler<CreateWineCommand, CreateWineResult>
    {
        public async Task<CreateWineResult> Handle(CreateWineCommand command, CancellationToken cancellationToken)
        {
            var style = await session.LoadAsync<Models.Style>(command.StyleId);
            var variety = await session.LoadAsync<Models.Variety>(command.VarietyId);

            if (style is null) { 
                throw new StyleNotFoundException();
            }
            if (variety is null) { 
                throw new VarietyNotFoundException();
            }

            var wine = new Models.Wine()
            {
                Name = command.Name,
                Description = command.Description,
                Year = command.Year,
                Price = command.Price,
                Image = command.Image,
                Style = style,
                Variety = variety
            };

            session.Store(wine);
            await session.SaveChangesAsync();
            return new CreateWineResult(wine.Id);
        }
    }
}
