using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;

namespace RestaurantLibrary.Connections
{
    public class TextFileConnector : IConnection
    {
        /// <summary>
        /// Adds row to file
        /// </summary>
        /// <param name="product">The product information.</param>
        /// <returns>The product information with unique identifier.</returns>
        public void CreateProduct(ProductModel product)
        {
            List<ProductModel> products = TextFileProcessor.GetProductRowsFrom();

            int newId = FindNewAvailableProductId(products);
            product.Id = newId;

            products.Add(product);

            TextFileProcessor.SaveToProductsFile(products);
        }

        /// <summary>
        /// Finds new highest unique identifier for product.
        /// </summary>
        /// <param name="products">List of prodcts to find new unique identifier from.</param>
        /// <returns>Returns new unique identifier to use.</returns>
        private int FindNewAvailableProductId(List<ProductModel> products)
        {
            if (products.Count == 0)
            {
                return 1;
            }

            return products.OrderByDescending(product => product.Id).First().Id + 1;
        }

        /// <summary>
        /// Saves menu item to file.
        /// </summary>
        /// <param name="menuItem">Menu item which is being saved to file.</param>
        public void CreateMenuItem(MenuItemModel menuItem)
        {
            List<MenuItemModel> menuItems = TextFileProcessor.GetMenuItemRowsFrom();

            int newId = FindNewAvailableMenuItemId(menuItems);
            menuItem.Id = newId;

            menuItems.Add(menuItem);

            TextFileProcessor.SaveToMenuItemsFile(menuItems);
        }

        /// <summary>
        /// Finds new highest unique identifier for menu item.
        /// </summary>
        /// <param name="menuItems">List of menu items to find new unique identifier from.</param>
        /// <returns>Returns new unique identifier to use.</returns>
        private int FindNewAvailableMenuItemId(List<MenuItemModel> menuItems)
        {
            if (menuItems.Count == 0)
            {
                return 1;
            }

            return menuItems.OrderByDescending(menuItem => menuItem.Id).First().Id + 1;
        }

        /// <summary>
        /// Saves order to file.
        /// </summary>
        /// <param name="menuItem">Order which is being saved to file.</param>
        public void CreateOrder(OrderModel order)
        {
            List<OrderModel> orders = TextFileProcessor.GetOrderRowsFrom();

            int newId = FindNewAvailableOrderId(orders);
            order.Id = newId;

            orders.Add(order);

            TextFileProcessor.SaveToOrdersFile(orders);
        }

        /// <summary>
        /// Finds new highest unique identifier for order.
        /// </summary>
        /// <param name="menuItems">List of orders to find new unique identifier from.</param>
        /// <returns>Returns new unique identifier to use.</returns>
        private int FindNewAvailableOrderId(List<OrderModel> orders)
        {
            if (orders.Count == 0)
            {
                return 1;
            }

            return orders.OrderByDescending(order => order.Id).First().Id + 1;
        }

        /// <summary>
        /// Gets all products stored in file.
        /// </summary>
        /// <returns>Returns products from file.</returns>
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = TextFileProcessor.GetProductRowsFrom();

            return products;
        }

        /// <summary>
        /// Gets all menu items stored in file.
        /// </summary>
        /// <returns>Returns menu items from file.</returns>
        public List<MenuItemModel> GetAllMenuItems()
        {
            List<MenuItemModel> menuItems = TextFileProcessor.GetMenuItemRowsFrom();

            return menuItems;
        }

        /// <summary>
        /// Gets all orders stored in file.
        /// </summary>
        /// <returns>Returns menu items from file.</returns>
        public List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orders = TextFileProcessor.GetOrderRowsFrom();

            return orders;
        }

        /// <summary>
        /// Updates product in file with new values.
        /// </summary>
        /// <param name="id">Product's id which is being updated.</param>
        /// <param name="newProduct">New product values.</param>
        public void UpdateProduct(int id, ProductModel newProduct)
        {
            List<ProductModel> products = TextFileProcessor.GetProductRowsFrom();

            foreach (ProductModel product in products)
            {
                if (id == product.Id)
                {
                    UpdateProductWith(product, newProduct);
                    newProduct.Id = id;

                    TextFileProcessor.SaveToProductsFile(products);

                    return;
                }
            }
        }

        /// <summary>
        /// Changes product's values with new values.
        /// </summary>
        /// <param name="product">Product which is being updated.</param>
        /// <param name="newProduct">New product's values.</param>
        private void UpdateProductWith(ProductModel product, ProductModel newProduct)
        {
            product.Name = newProduct.Name;
            product.PortionCount = newProduct.PortionCount;
            product.Unit = newProduct.Unit;
            product.PortionSize = newProduct.PortionSize;
        }

        /// <summary>
        /// Updates menu item in file with new values.
        /// </summary>
        /// <param name="id">Menu item's id which is being updated.</param>
        /// <param name="newMenuItem">New menu item values.</param>
        public void UpdateMenuItem(int id, MenuItemModel newMenuItem)
        {
            List<MenuItemModel> menuItems = TextFileProcessor.GetMenuItemRowsFrom();

            foreach (MenuItemModel menuItem in menuItems)
            {
                if (id == menuItem.Id)
                {
                    UpdateMenuItemtWith(menuItem, newMenuItem);
                    newMenuItem.Id = id;

                    TextFileProcessor.SaveToMenuItemsFile(menuItems);

                    return;
                }
            }
        }

        /// <summary>
        /// Changes menu item's values with new values.
        /// </summary>
        /// <param name="menuItem">Menu item which is being updated.</param>
        /// <param name="newMenuItem">New menu item's values.</param>
        private void UpdateMenuItemtWith(MenuItemModel menuItem, MenuItemModel newMenuItem)
        {
            menuItem.Name = newMenuItem.Name;
            menuItem.Ingredients = newMenuItem.Ingredients;
        }

        /// <summary>
        /// Updates products in file.
        /// </summary>
        /// <param name="products">List of products which contains products with new values.</param>
        public void UpdateProductStock(List<ProductModel> products)
        {
            TextFileProcessor.SaveToProductsFile(products);
        }

        /// <summary>
        /// Removes product from file.
        /// </summary>
        /// <param name="id">Product's id which is being removed from file.</param>
        public void DeleteProduct(int id)
        {
            List<ProductModel> products = TextFileProcessor.GetProductRowsFrom();
            List<ProductModel> newProductList = new List<ProductModel>();

            foreach (ProductModel product in products)
            {
                if (product.Id != id)
                {
                    newProductList.Add(product);
                }
            }

            TextFileProcessor.SaveToProductsFile(newProductList);
        }

        /// <summary>
        /// Removes menu item from file.
        /// </summary>
        /// <param name="id">Menu item's id which is being removed from file.</param>
        public void DeleteMenuItem(int id)
        {
            List<MenuItemModel> menuItems = TextFileProcessor.GetMenuItemRowsFrom();
            List<MenuItemModel> newMenuItemList = new List<MenuItemModel>();

            foreach (MenuItemModel menuItem in menuItems)
            {
                if (menuItem.Id != id)
                {
                    newMenuItemList.Add(menuItem);
                }
            }

            TextFileProcessor.SaveToMenuItemsFile(newMenuItemList);
        }
    }
}
