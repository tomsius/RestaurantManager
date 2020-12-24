using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public class OrderModel
    {
        /// <summary>
        /// Represents unique identifier of order
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the date when order was created
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Represents items ordered from the menu
        /// </summary>
        public List<MenuItemModel> OrderedItems { get; set; } = new List<MenuItemModel>();
    }
}
