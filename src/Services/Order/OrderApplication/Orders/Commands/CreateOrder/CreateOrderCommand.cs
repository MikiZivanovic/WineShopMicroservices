using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using FluentValidation;
using OrderApplication.Dtos;

namespace OrderApplication.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto Order): ICommand<CreateOrderResult>;

    public record CreateOrderResult(Guid Id);


    public class CreateOrdercommandValidator : AbstractValidator<CreateOrderCommand> {

        public CreateOrdercommandValidator()
        {
            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name of order is required");
            RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
            RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems is required");
        }

    }
}
