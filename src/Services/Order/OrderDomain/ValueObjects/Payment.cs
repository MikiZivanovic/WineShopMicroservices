using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDomain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; } = default!;

        public string CardNumber { get; } = default!;

        public string Exparation { get; } = default!;

        public string CVV { get; } = default!;


        protected Payment() { }

        public Payment(string cardName, string cardNumber, string exparation, string cVV)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Exparation = exparation;
            CVV = cVV;
        }

        public static Payment Of(string cardName, string cardNumber, string exparation, string cVV) {

            ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
            ArgumentException.ThrowIfNullOrWhiteSpace(cVV);

            return new Payment( cardName,  cardNumber,  exparation,  cVV);
        }


    }
}
