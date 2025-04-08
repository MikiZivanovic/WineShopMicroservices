using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using FluentValidation;
using OrderApplication.Dtos;


namespace OrderApplication.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResult>;

    public record UpdateOrderResult(bool IsSuccess);

    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand> {

        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name of order is required");
            RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
            RuleFor(x => x.Order.Id).NotEmpty().WithMessage("OrderID is required");


        }

    }



}
