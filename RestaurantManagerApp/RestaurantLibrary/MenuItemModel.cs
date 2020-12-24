using System.Collections.Generic;

namespace RestaurantLibrary
{
    public class MenuItemModel
    {
        /// <summary>
        /// Represents unique identifier of menu item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the name of the menu item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the products required for the menu item
        /// </summary>
        public List<ProductModel> Ingredients { get; set; } = new List<ProductModel>();
    }
}
