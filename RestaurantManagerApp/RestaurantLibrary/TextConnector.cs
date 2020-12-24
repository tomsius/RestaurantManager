using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;

namespace RestaurantLibrary
{
    public class TextConnector : IConnection
    {
        /// TODO - Implement writing to file
        /// <summary>
        /// Adds row to file
        /// </summary>
        /// <param name="product">The product information.</param>
        /// <returns>The product information with unique identifier.</returns>
        public ProductModel CreateProduct(ProductModel product)
        {
            product.Id = 1;

            return product;
        }
    }
}
