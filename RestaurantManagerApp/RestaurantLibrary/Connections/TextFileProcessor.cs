using RestaurantLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace RestaurantLibrary.Connections
{
    public static class TextFileProcessor
    {
        /// <summary>
        /// Reads all products' rows from file.
        /// </summary>
        /// <param name="fileName">File to read.</param>
        /// <returns>Returns stored products in file.</returns>
        public static List<ProductModel> GetProductRowsFrom()
        {
            string fullFilePath = GetFullFilePath(GlobalConfig.ProductsFile);
            List<string> dataRows = LoadFile(fullFilePath);
            List<ProductModel> productList = ConvertToProductList(dataRows);

            return productList;
        }

        /// <summary>
        /// Build path to fileName.
        /// </summary>
        /// <param name="fileName">File to reach.</param>
        /// <returns>Returns full path to file.</returns>
        private static string GetFullFilePath(string fileName)
        {
            return ConfigurationManager.AppSettings["filePath"] + "\\" + fileName;
        }

        /// <summary>
        /// Reads all lines from file.
        /// </summary>
        /// <param name="pathToFile">Full path to file.</param>
        /// <returns>Returns read lines from file or empty list if file does not exist.</returns>
        private static List<string> LoadFile(string pathToFile)
        {
            if (!File.Exists(pathToFile))
            {
                return new List<string>();
            }

            List<string> dataRows = File.ReadLines(pathToFile).ToList();

            return dataRows;
        }

        /// <summary>
        /// Converts string list to ProductModel list.
        /// </summary>
        /// <param name="dataRows">Rows to convert.</param>
        /// <returns>Returns converte</returns>
        private static List<ProductModel> ConvertToProductList(List<string> dataRows)
        {
            List<ProductModel> productList = new List<ProductModel>();

            foreach (string row in dataRows)
            {
                ProductModel product = DeserializeProductFrom(row);

                productList.Add(product);
            }

            return productList;
        }

        /// <summary>
        /// Deserializes product from string.
        /// </summary>
        /// <param name="row">String to convert to product.</param>
        /// <returns>Returns deserialized product.</returns>
        private static ProductModel DeserializeProductFrom(string row)
        {
            string[] columns = row.Split(';');

            string productName = columns[1];
            string productCount = columns[2];
            string productUnit = columns[3];
            string portionSize = columns[4];
            ProductModel product = new ProductModel(productName, productCount, productUnit, portionSize);
            product.Id = int.Parse(columns[0]);

            return product;
        }

        /// <summary>
        /// Reads all menu items' rows from file.
        /// </summary>
        /// <returns>Returns stored menu items in file.</returns>
        public static List<MenuItemModel> GetMenuItemRowsFrom()
        {
            string fullFilePath = GetFullFilePath(GlobalConfig.MenuItemsFile);
            List<string> dataRows = LoadFile(fullFilePath);
            List<MenuItemModel> menuItemList = ConvertToMenuItemList(dataRows);

            return menuItemList;
        }

        /// <summary>
        /// Deserializes strings to menu item list.
        /// </summary>
        /// <param name="dataRows">String list to convert to menu item list.</param>
        /// <returns>Returns deserialized menu item list.</returns>
        private static List<MenuItemModel> ConvertToMenuItemList(List<string> dataRows)
        {
            List<MenuItemModel> menuItemList = new List<MenuItemModel>();

            foreach (string row in dataRows)
            {
                MenuItemModel menuItem = DeserializeMenuItemFrom(row);

                menuItemList.Add(menuItem);
            }

            return menuItemList;
        }

        /// <summary>
        /// Deserializes menu item from string.
        /// </summary>
        /// <param name="row">String to convert to product.</param>
        /// <returns>Returns deserialized menu item.</returns>
        private static MenuItemModel DeserializeMenuItemFrom(string row)
        {
            string[] columns = row.Split(';');

            string name = columns[1];
            string[] ingredientsIds = columns[2].Split(' ');

            List<ProductModel> ingredients = GetIngredientsByIds(ingredientsIds);

            MenuItemModel menuItem = new MenuItemModel(name, ingredients);
            menuItem.Id = int.Parse(columns[0]);

            return menuItem;
        }

        /// <summary>
        /// Deserializes strings to product list.
        /// </summary>
        /// <param name="ingredientsIds">String list to convert to product list.</param>
        /// <returns>Returns deserialized product list.</returns>
        private static List<ProductModel> GetIngredientsByIds(string[] ingredientsIds)
        {
            List<ProductModel> ingredients = new List<ProductModel>();
            List<ProductModel> products = GetProductRowsFrom();

            foreach (string id in ingredientsIds)
            {
                ingredients.Add(products.Where(product => product.Id == int.Parse(id)).First());
            }

            return ingredients;
        }

        /// <summary>
        /// Reads all orders' rows from file.
        /// </summary>
        /// <returns>Returns stored orders in file.</returns>
        public static List<OrderModel> GetOrderRowsFrom()
        {
            string fullFilePath = GetFullFilePath(GlobalConfig.OrdersFile);
            List<string> dataRows = LoadFile(fullFilePath);
            List<OrderModel> orderList = ConvertToOrderList(dataRows);

            return orderList;
        }

        /// <summary>
        /// Deserializes strings to order list.
        /// </summary>
        /// <param name="dataRows">String list to convert to order list.</param>
        /// <returns>Returns deserialized order list.</returns>
        private static List<OrderModel> ConvertToOrderList(List<string> dataRows)
        {
            List<OrderModel> orderList = new List<OrderModel>();

            foreach (string row in dataRows)
            {
                OrderModel order = DeserializeOrderFrom(row);

                orderList.Add(order);
            }

            return orderList;
        }

        /// <summary>
        /// Deserializes order from string.
        /// </summary>
        /// <param name="row">String to convert to order</param>
        /// <returns>Returns deserialized order.</returns>
        private static OrderModel DeserializeOrderFrom(string row)
        {
            string[] columns = row.Split(';');

            string date = columns[1];
            string[] menuItemsIds = columns[2].Split(' ');

            List<MenuItemModel> menuItem = GetMenuItemsByIds(menuItemsIds);

            OrderModel order = new OrderModel(DateTime.Parse(date), menuItem);
            order.Id = int.Parse(columns[0]);

            return order;
        }

        /// <summary>
        /// Deserializes strings to menu item list.
        /// </summary>
        /// <param name="menuItemsIds">String list to convert to menu item list.</param>
        /// <returns>Returns deserialized menu item list.</returns>
        private static List<MenuItemModel> GetMenuItemsByIds(string[] menuItemsIds)
        {
            List<MenuItemModel> output = new List<MenuItemModel>();
            List<MenuItemModel> menuItems = GetMenuItemRowsFrom();

            foreach (string id in menuItemsIds)
            {
                output.Add(menuItems.Where(menuItem => menuItem.Id == int.Parse(id)).First());
            }

            return output;
        }

        /// <summary>
        /// Writes products to file.
        /// </summary>
        /// <param name="products">Product list to save.</param>
        public static void SaveToProductsFile(List<ProductModel> products)
        {
            List<string> rows = new List<string>();

            foreach (ProductModel product in products)
            {
                rows.Add(ConvertProductToString(product));
            }

            File.WriteAllLines(GetFullFilePath(GlobalConfig.ProductsFile), rows);
        }

        /// <summary>
        /// Serializes product to string.
        /// </summary>
        /// <param name="product">Product to convert to string.</param>
        /// <returns>Returns serialized string.</returns>
        private static string ConvertProductToString(ProductModel product)
        {
            return product.Id + ";" + product.Name + ";" + product.PortionCount + ";" + product.Unit + ";" + product.PortionSize;
        }

        /// <summary>
        /// Writes menu items to file.
        /// </summary>
        /// <param name="menuItems">Menu item list to save.</param>
        public static void SaveToMenuItemsFile(List<MenuItemModel> menuItems)
        {
            List<string> rows = new List<string>();

            foreach (MenuItemModel menuItem in menuItems)
            {
                rows.Add(ConvertMenuItemToString(menuItem));
            }

            File.WriteAllLines(GetFullFilePath(GlobalConfig.MenuItemsFile), rows);
        }

        /// <summary>
        /// Serializes menu item to string.
        /// </summary>
        /// <param name="menuItem">Menu item to convert to string.</param>
        /// <returns>Returns serialized string.</returns>
        private static string ConvertMenuItemToString(MenuItemModel menuItem)
        {
            return menuItem.Id + ";" + menuItem.Name + ";" + ConvertProductIdsToString(menuItem.Ingredients);
        }

        /// <summary>
        /// Serializes products' ids to string.
        /// </summary>
        /// <param name="ingredients">Products' ids list to convert to string.</param>
        /// <returns>Returnss serialized string.</returns>
        private static string ConvertProductIdsToString(List<ProductModel> ingredients)
        {
            string output = string.Empty;

            if (ingredients.Count == 0)
            {
                return output;
            }

            foreach (ProductModel product in ingredients)
            {
                output += product.Id + " ";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        /// <summary>
        /// Writes orders to file.
        /// </summary>
        /// <param name="orders">Order list to save.</param>
        public static void SaveToOrdersFile(List<OrderModel> orders)
        {
            List<string> rows = new List<string>();

            foreach (OrderModel order in orders)
            {
                rows.Add(ConvertOrderToString(order));
            }

            File.WriteAllLines(GetFullFilePath(GlobalConfig.OrdersFile), rows);
        }

        /// <summary>
        /// Serializes order to string.
        /// </summary>
        /// <param name="order">Order to convert to string.</param>
        /// <returns>Returns serialized string.</returns>
        private static string ConvertOrderToString(OrderModel order)
        {
           return order.Id + ";" + order.Date + ";" + ConvertMenuItemIdsToString(order.OrderedItems);
        }

        /// <summary>
        /// Serializes menu items' ids to string.
        /// </summary>
        /// <param name="orderedItems">Menu items' ids list to convert to string.</param>
        /// <returns>Returnss serialized string.</returns>
        private static string ConvertMenuItemIdsToString(List<MenuItemModel> orderedItems)
        {
            string output = string.Empty;

            if (orderedItems.Count == 0)
            {
                return output;
            }

            foreach (MenuItemModel menuItem in orderedItems)
            {
                output += menuItem.Id + " ";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }
    }
}
