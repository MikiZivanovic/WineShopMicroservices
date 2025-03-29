using BuildingBlocks.Exceptions;

namespace CartAPI.Excepions
{
    public class CartNotFoundException :  NotFoundException
    {
        public CartNotFoundException(string userName) : base("Cart",userName) 
        {

        }
    }
}
