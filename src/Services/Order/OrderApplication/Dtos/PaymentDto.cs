using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.Dtos
{
    public record PaymentDto(string CardName,string CardNumber,string Exparation,string Cvv);
    
}
