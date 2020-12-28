using RestaurantLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public static class OrderLogic
    {
        /// <summary>
        /// Check if all ordered menu items' ingredients are in stock. Throws ArgumentException if empty list is given.
        /// </summary>
        /// <param name="orderedMenuItems">Ordered menu items of order.</param>
        /// <returns></returns>
        public static bool AreOrderedMenuItemsProductsInStock(List<MenuItemModel> orderedMenuItems)
        {
            if (orderedMenuItems.Count == 0)
            {
                throw new ArgumentException("Ordered menu item list can not be empty.");
            }

            foreach (MenuItemModel menuItem in orderedMenuItems)
            {
                foreach (ProductModel product in menuItem.Ingredients)
                {
                    if (StockLogic.IsProductInStock(product.Id))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Goes through all of the order item's ingredients and reduces them by 1 in stock. Throws ArgumentException if empty list is given.
        /// </summary>
        /// <param name="orderedMenuItems">Ordered menu items of order.</param>
        public static void ReduceProductsInStock(List<MenuItemModel> orderedMenuItems)
        {
            if (orderedMenuItems.Count == 0)
            {
                throw new ArgumentException("Ordered menu item list can not be empty.");
            }

            List<ProductModel> productsInStock = GlobalConfig.Connection.GetAllProducts();

            foreach (MenuItemModel menuItem in orderedMenuItems)
            {
                foreach (ProductModel product in menuItem.Ingredients)
                {
                    StockLogic.ReduceProductInStock(productsInStock, product.Id);
                }
            }

            GlobalConfig.Connection.UpdateProductStock(productsInStock);
        }
    }
}
