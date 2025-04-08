using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDomain.Exceptions;

namespace OrderDomain.ValueObjects
{
    public record WineId
    {
        public Guid Value { get; }

        private WineId(Guid value) { Value = value; }


        public static WineId Of(Guid value) {

            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty) {

                throw new DomainException("Value for WineId is empty");
            }

            return new WineId(value);
        }
    }
}
