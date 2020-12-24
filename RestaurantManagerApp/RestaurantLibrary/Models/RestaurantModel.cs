using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary.Models
{
    public class RestaurantModel
    {
        /// <summary>
        /// Represents stock of the restaurant
        /// </summary>
        public StockModel Stock { get; set; }

        /// <summary>
        /// Represents the menu available in the restaurant
        /// </summary>
        public MenuModel Menu { get; set; }

        /// <summary>
        /// Represents customers' orders
        /// </summary>
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
