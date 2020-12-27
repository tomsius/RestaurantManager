using RestaurantLibrary.Models;

namespace RestaurantManagerUI
{
    public interface IProductChanger
    {
        void CompleteProductUpdate(ProductModel newProduct);
    }
}