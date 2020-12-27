using System.Collections.Generic;

namespace RestaurantLibrary.Models
{
    public class MenuItemModel
    {
        /// <summary>
        /// Represents unique identifier of menu item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the name of the menu item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the products required for the menu item.
        /// </summary>
        public List<ProductModel> Ingredients { get; set; } = new List<ProductModel>();

        /// <summary>
        /// Represents MenuItemModel object.
        /// </summary>
        public string DisplayName
        {
            get
            {
                string ingredients = "";
                foreach (ProductModel product in Ingredients)
                {
                    ingredients += product.Id + " ";
                }

                ingredients = ingredients.Substring(0, ingredients.Length - 1);

                return string.Format("{0,-4}{1,-25}{2,-16}", Id.ToString(), Name, ingredients);
            }
        }

        /// <summary>
        /// Creates object with initialized values.
        /// </summary>
        /// <param name="name">Menu item's name.</param>
        /// <param name="ingredients">Menu item's ingredients.</param>
        public MenuItemModel(string name, List<ProductModel> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }
}
