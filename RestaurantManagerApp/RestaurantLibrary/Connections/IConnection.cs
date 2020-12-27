using RestaurantLibrary.Models;
using System.Collections.Generic;

namespace RestaurantLibrary.Connections
{
    public interface IConnection
    {
        void CreateProduct(ProductModel product);
        void CreateMenuItem(MenuItemModel menuItem);
        void CreateOrder(OrderModel order);
        List<ProductModel> GetAllProducts();
        List<MenuItemModel> GetAllMenuItems();
        List<OrderModel> GetAllOrders();
        void UpdateProduct(int id, ProductModel newProduct);
        void UpdateMenuItem(int id, MenuItemModel newMenuItem);
        void UpdateProductStock(List<ProductModel> products);
        void DeleteProduct(int id);
        void DeleteMenuItem(int id);
    }
}
