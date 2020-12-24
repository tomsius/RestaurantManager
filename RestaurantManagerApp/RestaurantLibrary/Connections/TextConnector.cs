using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;

namespace RestaurantLibrary.Connections
{
    public class TextConnector : IConnection
    {
        /// <summary>
        /// Represents file name for ProductModel rows.
        /// </summary>
        private const string ProductsFile = "Products.csv";

        /// <summary>
        /// Adds row to file
        /// </summary>
        /// <param name="product">The product information.</param>
        /// <returns>The product information with unique identifier.</returns>
        public ProductModel CreateProduct(ProductModel product)
        {
            List<ProductModel> products = TextFileUtilities.GetProductRowsFrom(ProductsFile);

            int newId = FindNewAvailableProductId(products);
            product.Id = newId;

            products.Add(product);

            TextFileUtilities.SaveToProductsFile(products, ProductsFile);

            return product;
        }

        private int FindNewAvailableProductId(List<ProductModel> products)
        {
            if (products.Count == 0)
            {
                return 1;
            }

            return products.OrderByDescending(p => p.Id).First().Id + 1;
        }
    }
}
