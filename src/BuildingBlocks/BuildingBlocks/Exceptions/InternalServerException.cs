

namespace BuildingBlocks.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string nessage) : base(nessage)
        {

        }
        public InternalServerException(string nessage, string details) : base(nessage)
        {
            Details = details;
        }
        public string? Details { get; }
    }
}
