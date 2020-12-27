using RestaurantLibrary.Models;
using System.Collections.Generic;

namespace RestaurantLibrary.Connections
{
    public interface IConnection
    {
        ProductModel CreateProduct(ProductModel product);
        MenuItemModel CreateMenuItem(MenuItemModel menuItem);
        List<ProductModel> GetAllProducts();
        ProductModel UpdateProduct(ProductModel product);
        MenuItemModel UpdateMenuItem(MenuItemModel menuItem);

    }
}
