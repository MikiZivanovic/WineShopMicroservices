

namespace CatalogAPI.Exceptions
{
    public class WineNotFoundException : NotFoundException
    {
        public WineNotFoundException(Guid Id) : base("Wine",Id) { }
    }
}
