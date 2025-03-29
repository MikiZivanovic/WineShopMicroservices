using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string nessage) : base(nessage)
        {

        }
        public BadRequestException(string nessage, string details) : base(nessage)
        {
            Details = details;
        }
        public string? Details { get; }
    }
}
