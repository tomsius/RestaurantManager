using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary.Models
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

        public string DisplayName
        {
            get
            {
                string orderedItems = "";
                foreach (MenuItemModel menuItem in OrderedItems)
                {
                    orderedItems += menuItem.Id + " ";
                }

                orderedItems = orderedItems.Substring(0, orderedItems.Length - 1);

                return string.Format("{0,-4}{1,-24}{2,-16}", Id.ToString(), Date, orderedItems);
            }
        }

        public OrderModel(DateTime date, List<MenuItemModel> orderedItems)
        {
            Date = date;
            OrderedItems = orderedItems;
        }
    }
}
