using System.Collections.Generic;

namespace RestaurantLibrary
{
    public class StockModel
    {
        /// <summary>
        /// Represents the products in stock
        /// </summary>
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
