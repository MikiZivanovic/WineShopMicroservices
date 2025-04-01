
using CartAPI.Data;
using DiscountGRPC;
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
    public class StoreCartCommandHandler(ICartRepository repository,DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StoreCartCommand,StoreCartResult>
    {
        
        public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
        {

            await CountDiscount(command.ShoppingCart, cancellationToken);

             await repository.StoreCart(command.ShoppingCart,cancellationToken);
            return new StoreCartResult(command.ShoppingCart.UserName);
        }

        private async Task CountDiscount(ShoppingCart cart, CancellationToken cancellationToken) {
            foreach (var item in cart.Items)
            {

                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest() { ProductName = item.WineName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
        }
    }
}
