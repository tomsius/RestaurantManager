using RestaurantLibrary.Models;
using System.Collections.Generic;

namespace RestaurantLibrary.Connections
{
    public interface IConnection
    {
        ProductModel CreateProduct(ProductModel product);
        List<ProductModel> GetAllProducts();
        MenuItemModel CreateMenuItem(MenuItemModel menuItem);
    }
}
