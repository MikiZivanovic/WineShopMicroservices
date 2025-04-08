using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDomain.Exceptions;

namespace OrderDomain.ValueObjects
{
    public record OrderId
    {
        public Guid Value { get; }

        private OrderId(Guid value) => Value = value;
        public static OrderId Of(Guid value) {

            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty) {

                throw new DomainException("Value for orderId is empty");
            }

            return new OrderId(value ) ;
        }
    }
}
