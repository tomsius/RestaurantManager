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
        /// Reads all data rows from file.
        /// </summary>
        /// <param name="fileName">File to read.</param>
        /// <returns>Return stored products in file.</returns>
        public static List<ProductModel> GetProductRowsFrom(string fileName)
        {
            string fullFilePath = GetFullFilePath(fileName);
            List<string> dataRows = LoadFile(fullFilePath);
            List<ProductModel> productList = ConvertToProductList(dataRows);

            return productList;
        }

        /// <summary>
        /// Build path to fileName
        /// </summary>
        /// <param name="fileName">File to reach.</param>
        /// <returns>Return full path to file.</returns>
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
                string[] columns = row.Split(';');

                string productName = columns[1];
                string productCount = columns[2];
                string productUnit = columns[3];
                string portionSize = columns[4];
                ProductModel product = new ProductModel(productName, productCount, productUnit, portionSize);
                product.Id = int.Parse(columns[0]);

                productList.Add(product);
            }

            return productList;
        }

        public static void SaveToProductsFile(List<ProductModel> products, string fileName)
        {
            List<string> rows = new List<string>();

            foreach (ProductModel product in products)
            {
                rows.Add(ConvertProductToString(product));
            }

            File.WriteAllLines(GetFullFilePath(fileName), rows);
        }

        private static string ConvertProductToString(ProductModel product)
        {
            return product.Id + ";" + product.Name + ";" + product.PortionCount + ";" + product.Unit + ";" + product.PortionSize;
        }

        public static List<MenuItemModel> GetMenuItemsRowsFrom(string menuItemsFileName, string productsFileName)
        {
            string fullFilePath = GetFullFilePath(menuItemsFileName);
            List<string> dataRows = LoadFile(fullFilePath);
            List<MenuItemModel> menuItemList = ConvertToMenuItemList(dataRows, productsFileName);

            return menuItemList;
        }

        private static List<MenuItemModel> ConvertToMenuItemList(List<string> dataRows, string productsFileName)
        {
            List<MenuItemModel> menuItemList = new List<MenuItemModel>();

            foreach (string row in dataRows)
            {
                string[] columns = row.Split(';');

                string name = columns[1];
                string[] ingredientsIds = columns[2].Split(' ');

                List<ProductModel> ingredients = GetIngredientsByIds(ingredientsIds, productsFileName);

                MenuItemModel menuItem = new MenuItemModel(name, ingredients);
                menuItem.Id = int.Parse(columns[0]);

                menuItemList.Add(menuItem);
            }

            return menuItemList;
        }

        private static List<ProductModel> GetIngredientsByIds(string[] ingredientsIds, string productsFileName)
        {
            List<ProductModel> ingredients = new List<ProductModel>();
            List<ProductModel> products = GetProductRowsFrom(productsFileName);

            foreach (string id in ingredientsIds)
            {
                ingredients.Add(products.Where(product => product.Id == int.Parse(id)).First());
            }

            return ingredients;
        }

        public static void SaveToMenuItemsFile(List<MenuItemModel> menuItems, string fileName)
        {
            List<string> rows = new List<string>();

            foreach (MenuItemModel menuItem in menuItems)
            {
                rows.Add(ConvertMenuItemToString(menuItem));
            }

            File.WriteAllLines(GetFullFilePath(fileName), rows);
        }

        private static string ConvertMenuItemToString(MenuItemModel menuItem)
        {
            return menuItem.Id + ";" + menuItem.Name + ";" + ConvertProductIdsToString(menuItem.Ingredients);
        }

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

        public static List<OrderModel> GetOrderRowsFrom(string orderFileName, string menuItemFile, string productFile)
        {
            string fullFilePath = GetFullFilePath(orderFileName);
            List<string> dataRows = LoadFile(fullFilePath);
            List<OrderModel> orderList = ConvertToOrderList(dataRows, menuItemFile, productFile);

            return orderList;
        }

        private static List<OrderModel> ConvertToOrderList(List<string> dataRows, string menuItemFile, string productFile)
        {
            List<OrderModel> orderList = new List<OrderModel>();

            foreach (string row in dataRows)
            {
                string[] columns = row.Split(';');

                string date = columns[1];
                string[] menuItemsIds = columns[2].Split(' ');

                List<MenuItemModel> menuItem = GetMenuItemsByIds(menuItemsIds, menuItemFile, productFile);

                OrderModel order = new OrderModel(DateTime.Parse(date), menuItem);
                order.Id = int.Parse(columns[0]);

                orderList.Add(order);
            }

            return orderList;
        }

        private static List<MenuItemModel> GetMenuItemsByIds(string[] menuItemsIds, string menuItemFile, string productFile)
        {
            List<MenuItemModel> output = new List<MenuItemModel>();
            List<MenuItemModel> menuItems = GetMenuItemsRowsFrom(menuItemFile, productFile);

            foreach (string id in menuItemsIds)
            {
                output.Add(menuItems.Where(menuItem => menuItem.Id == int.Parse(id)).First());
            }

            return output;
        }

        public static void SaveToOrdersFile(List<OrderModel> orders, string fileName)
        {
            List<string> rows = new List<string>();

            foreach (OrderModel order in orders)
            {
                rows.Add(ConvertOrderToString(order));
            }

            File.WriteAllLines(GetFullFilePath(fileName), rows);
        }

        private static string ConvertOrderToString(OrderModel order)
        {
           return order.Id + ";" + order.Date + ";" + ConvertMenuItemIdsToString(order.OrderedItems);
        }

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
