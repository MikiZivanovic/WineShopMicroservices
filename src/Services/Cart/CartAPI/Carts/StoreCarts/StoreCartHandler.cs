
using CartAPI.Data;
using FluentValidation;

namespace CartAPI.Carts.StoreCarts
{
    public record StoreCartCommand(ShoppingCart ShoppingCart ) : ICommand<StoreCartResult>;
    public record StoreCartResult(string UserName);

    public class StoreCartCommandValidator : AbstractValidator<StoreCartCommand> { 
    
        public StoreCartCommandValidator() {

            RuleFor(x => x.ShoppingCart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.ShoppingCart.UserName).NotEmpty().WithMessage("Username is required");
        }
    }
    public class StoreCartCommandHandler(ICartRepository repository) : ICommandHandler<StoreCartCommand,StoreCartResult>
    {
        
        public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
        {
             await repository.StoreCart(command.ShoppingCart,cancellationToken);
            return new StoreCartResult(command.ShoppingCart.UserName);
        }
    }
}
