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
        /// Finds new highest unique identifier.
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
        /// Gets all products stored in file.
        /// </summary>
        /// <returns>Returns products from file.</returns>
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = TextFileProcessor.GetProductRowsFrom();

            return products;
        }

        public List<MenuItemModel> GetAllMenuItems()
        {
            List<MenuItemModel> menuItems = TextFileProcessor.GetMenuItemsRowsFrom();

            return menuItems;
        }

        public void CreateMenuItem(MenuItemModel menuItem)
        {
            List<MenuItemModel> menuItems = TextFileProcessor.GetMenuItemsRowsFrom();

            int newId = FindNewAvailableMenuItemId(menuItems);
            menuItem.Id = newId;

            menuItems.Add(menuItem);

            TextFileProcessor.SaveToMenuItemsFile(menuItems);
        }

        private int FindNewAvailableMenuItemId(List<MenuItemModel> menuItems)
        {
            if (menuItems.Count == 0)
            {
                return 1;
            }

            return menuItems.OrderByDescending(menuItem => menuItem.Id).First().Id + 1;
        }

        public void UpdateProduct(int id, ProductModel newProduct)
        {
            List<ProductModel> products = TextFileProcessor.GetProductRowsFrom();

            foreach (ProductModel product in products)
            {
                if (id == product.Id)
                {
                    UpdateProductWith(product, newProduct);
                    TextFileProcessor.SaveToProductsFile(products);
                }
            }
        }

        private void UpdateProductWith(ProductModel product, ProductModel newProduct)
        {
            product.Name = newProduct.Name;
            product.PortionCount = newProduct.PortionCount;
            product.Unit = newProduct.Unit;
            product.PortionSize = newProduct.PortionSize;
        }

        public void UpdateMenuItem(int id, MenuItemModel newMenuItem)
        {
            List<MenuItemModel> menuItems = TextFileProcessor.GetMenuItemsRowsFrom();

            foreach (MenuItemModel menuItem in menuItems)
            {
                if (id == menuItem.Id)
                {
                    UpdateMenuItemtWith(menuItem, newMenuItem);
                    TextFileProcessor.SaveToMenuItemsFile(menuItems);
                }
            }
        }

        private void UpdateMenuItemtWith(MenuItemModel menuItem, MenuItemModel newMenuItem)
        {
            menuItem.Name = newMenuItem.Name;
            menuItem.Ingredients = newMenuItem.Ingredients;
        }

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

        public void DeleteMenuItem(int id)
        {
            List<MenuItemModel> menuItems = TextFileProcessor.GetMenuItemsRowsFrom();
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

        public void CreateOrder(OrderModel order)
        {
            List<OrderModel> orders = TextFileProcessor.GetOrderRowsFrom();

            int newId = FindNewAvailableOrderId(orders);
            order.Id = newId;

            orders.Add(order);

            TextFileProcessor.SaveToOrdersFile(orders);
        }

        private int FindNewAvailableOrderId(List<OrderModel> orders)
        {
            if (orders.Count == 0)
            {
                return 1;
            }

            return orders.OrderByDescending(order => order.Id).First().Id + 1;
        }

        public void UpdateProductStock(List<ProductModel> products)
        {
            TextFileProcessor.SaveToProductsFile(products);
        }

        public List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orders = TextFileProcessor.GetOrderRowsFrom();

            return orders;
        }
    }
}
