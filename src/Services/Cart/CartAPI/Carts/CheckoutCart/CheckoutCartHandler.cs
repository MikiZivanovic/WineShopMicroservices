using BuildingBlocksMessaging.Events;
using CartAPI.Data;
using CartAPI.Dtos;
using MassTransit;

namespace CartAPI.Carts.CheckoutCart
{
    public record CheckoutCartCommand(CartCheckoutDto CheckoutDto) : ICommand<CheckoutCartResult>;

    public record CheckoutCartResult(bool IsSuccess);

    public class CheckoutCartCommandValidator : AbstractValidator<CheckoutCartCommand> {

        public CheckoutCartCommandValidator()
        {
            RuleFor(x => x.CheckoutDto).NotNull().WithMessage("Cart must have something");
            RuleFor(x => x.CheckoutDto.UserName).NotEmpty().WithMessage("Cart does not have user");
            RuleFor(x => x.CheckoutDto.Items).NotEmpty().WithMessage("Cart must have at least one item");
        
        }


    }

    public class CheckoutCartHandler(ICartRepository repository, IPublishEndpoint publishEndpoint) : ICommandHandler<CheckoutCartCommand, CheckoutCartResult>
    {
        public async Task<CheckoutCartResult> Handle(CheckoutCartCommand command, CancellationToken cancellationToken)
        {
            var cart = await repository.GetCart(command.CheckoutDto.UserName, cancellationToken);

            if (cart is null) {

                return new CheckoutCartResult(false);
            }

            var eventMessage = command.CheckoutDto.Adapt<CartCheckoutEvent>();

            eventMessage.TotalPrice = cart.TotalPrice;

            await publishEndpoint
                .Publish(eventMessage);

            await repository.DeleteCart(command.CheckoutDto.UserName, cancellationToken);

            return new CheckoutCartResult(true);

        }
    }
}
