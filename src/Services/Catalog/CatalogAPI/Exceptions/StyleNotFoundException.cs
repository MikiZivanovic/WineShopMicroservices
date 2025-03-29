namespace CatalogAPI.Exceptions
{
    public class StyleNotFoundException :Exception
    {
        public StyleNotFoundException() : base("Style is not found") { }
    }
}
