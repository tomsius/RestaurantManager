using RestaurantLibrary.Models;
using System.Collections.Generic;

namespace RestaurantLibrary.Connections
{
    public interface IConnection
    {
        ProductModel CreateProduct(ProductModel product);
        MenuItemModel CreateMenuItem(MenuItemModel menuItem);
        List<ProductModel> GetAllProducts();
        List<MenuItemModel> GetAllMenuItems();
        ProductModel UpdateProduct(int id, ProductModel newProduct);
        MenuItemModel UpdateMenuItem(int id, MenuItemModel newMenuItem);
        void RemoveProduct(int id);
        void RemoveMenuItem(int id);
    }
}
