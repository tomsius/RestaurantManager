using System.Collections.Generic;

namespace RestaurantLibrary.Models
{
    public class MenuModel
    {
        /// <summary>
        /// Represents items available in the menu
        /// </summary>
        public List<MenuItemModel> MenuItems { get; set; } = new List<MenuItemModel>();
    }
}
