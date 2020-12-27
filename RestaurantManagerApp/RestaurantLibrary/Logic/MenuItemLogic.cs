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
        public static List<ProductModel> GetNotUsedIngredients(MenuItemModel menuItem)
        {
            List<ProductModel> allIngredients = GlobalConfig.Connection.GetAllProducts();
            List<ProductModel> notUsedIngredients = new List<ProductModel>();

            foreach (ProductModel product in allIngredients)
            {
                bool contains = false;
                foreach (ProductModel ingredient in menuItem.Ingredients)
                {
                    if (product.Id == ingredient.Id)
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    notUsedIngredients.Add(product);
                }
            }

            return notUsedIngredients;
        }
    }
}
