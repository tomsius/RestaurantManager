using RestaurantLibrary.Models;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace RestaurantLibrary.Connections
{
    public static class TextFileUtilities
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
    }
}
