using RestaurantLibrary.Models;
using System.Collections.Generic;

namespace RestaurantLibrary.Connections
{
    public interface IConnection
    {
        ProductModel CreateProduct(ProductModel product);
        MenuItemModel CreateMenuItem(MenuItemModel menuItem);
        OrderModel CreateOrder(OrderModel order);
        List<ProductModel> GetAllProducts();
        List<MenuItemModel> GetAllMenuItems();
        List<OrderModel> GetAllOrders();
        ProductModel UpdateProduct(int id, ProductModel newProduct);
        MenuItemModel UpdateMenuItem(int id, MenuItemModel newMenuItem);
        void UpdateProductStock(List<ProductModel> products);
        void DeleteProduct(int id);
        void DeleteMenuItem(int id);
    }
}
