using RestaurantLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary.Logic
{
    public static class MenuItemLogic
    {
        /// <summary>
        /// Gets ingredients which are in stock but not used in menu item. Throws ArgumentException exception if parameter is null.
        /// </summary>
        /// <param name="menuItem">Menu item which is being checked.</param>
        /// <returns>Returns not used products in menu item.</returns>
        public static List<ProductModel> GetNotUsedIngredients(MenuItemModel menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentException("Menu item object can not be null.");
            }

            List<ProductModel> allIngredients = GlobalConfig.Connection.GetAllProducts();
            List<ProductModel> notUsedIngredients = new List<ProductModel>();

            foreach (ProductModel product in allIngredients)
            {
                if (IsProductNotUsedInMenuItem(product, menuItem))
                {
                    notUsedIngredients.Add(product);
                }
            }

            return notUsedIngredients;
        }

        /// <summary>
        /// Checks if product is not used in menu item.
        /// </summary>
        /// <param name="product">Product which is being checked if it is in menu item.</param>
        /// <param name="menuItem">Menu item against which product is being checked.</param>
        /// <returns>Returns true if product is not in menu item's ingredient list.</returns>
        private static bool IsProductNotUsedInMenuItem(ProductModel product, MenuItemModel menuItem)
        {
            foreach (ProductModel ingredient in menuItem.Ingredients)
            {
                if (product.Id == ingredient.Id)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
