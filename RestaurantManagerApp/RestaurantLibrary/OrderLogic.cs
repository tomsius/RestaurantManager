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
        public static bool AreOrderedMenuItemsProductsInStock(List<MenuItemModel> orderedMenuItems)
        {
            List<ProductModel> productsInStock = GlobalConfig.Connection.GetAllProducts();

            foreach (MenuItemModel menuItem in orderedMenuItems)
            {
                foreach (ProductModel product in menuItem.Ingredients)
                {
                    if (StockLogic.IsProductInStock(productsInStock, product.Id))
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

        public static void ReduceProductsInStock(List<MenuItemModel> orderedMenuItems)
        {
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
