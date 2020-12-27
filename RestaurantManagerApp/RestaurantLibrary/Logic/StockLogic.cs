using RestaurantLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public static class StockLogic
    {
        /// <summary>
        /// Checks if product is in stock.
        /// </summary>
        /// <param name="id">Product's id which is being checked.</param>
        /// <returns>Retruns true if product is in stock. Returns false if product is not in stock.</returns>
        public static bool IsProductInStock(int id)
        {
            List<ProductModel> products = GlobalConfig.Connection.GetAllProducts();

            bool isInStock = products.Where(p => p.Id == id).First().PortionCount - 1 >= 0;

            return isInStock;
        }

        /// <summary>
        /// Reduces product's amount in stock by 1.
        /// </summary>
        /// <param name="products">Products in stock.</param>
        /// <param name="id">Product's id whose amount is being reduced.</param>
        public static void ReduceProductInStock(List<ProductModel> products, int id)
        {
            products.Where(p => p.Id == id).First().PortionCount--;
        }
    }
}
