using RestaurantLibrary.Models;

namespace RestaurantLibrary
{
    public interface IConnection
    {
        ProductModel CreateProduct(ProductModel product);
    }
}
