using RestaurantLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public static class StockLogic
    {
        public static bool IsProductInStock(List<ProductModel> products, int id)
        {
            return products.Where(p => p.Id == id).First().PortionCount - 1 >= 0;
        }

        public static void ReduceProductInStock(List<ProductModel> products, int id)
        {
            products.Where(p => p.Id == id).First().PortionCount--;
        }
    }
}
