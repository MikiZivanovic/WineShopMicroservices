namespace CatalogAPI.Exceptions
{
    public class VarietyNotFoundException : Exception
    {
        public VarietyNotFoundException() : base("Variety is not found"){ }
    }
}
