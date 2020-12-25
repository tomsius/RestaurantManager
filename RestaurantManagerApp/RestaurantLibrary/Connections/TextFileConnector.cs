using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantLibrary.Models;

namespace RestaurantLibrary.Connections
{
    public class TextFileConnector : IConnection
    {
        /// <summary>
        /// Represents file name for ProductModel rows.
        /// </summary>
        private const string ProductsFile = "Products.csv";

        private const string MenuItemsFile = "MenuItems.csv";

        /// <summary>
        /// Adds row to file
        /// </summary>
        /// <param name="product">The product information.</param>
        /// <returns>The product information with unique identifier.</returns>
        public ProductModel CreateProduct(ProductModel product)
        {
            List<ProductModel> products = TextFileProcessor.GetProductRowsFrom(ProductsFile);

            int newId = FindNewAvailableProductId(products);
            product.Id = newId;

            products.Add(product);

            TextFileProcessor.SaveToProductsFile(products, ProductsFile);

            return product;
        }

        /// <summary>
        /// Finds new highest unique identifier.
        /// </summary>
        /// <param name="products">List of prodcts to find new unique identifier from.</param>
        /// <returns>Returns new unique identifier to use.</returns>
        private int FindNewAvailableProductId(List<ProductModel> products)
        {
            if (products.Count == 0)
            {
                return 1;
            }

            return products.OrderByDescending(product => product.Id).First().Id + 1;
        }

        /// <summary>
        /// Gets all products stored in file.
        /// </summary>
        /// <returns>Returns products from file.</returns>
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = TextFileProcessor.GetProductRowsFrom(ProductsFile);

            return products;
        }

        public MenuItemModel CreateMenuItem(MenuItemModel menuItem)
        {
            List<MenuItemModel> menuItems = TextFileProcessor.GetMenuItemsRowsFrom(MenuItemsFile, ProductsFile);

            int newId = FindNewAvailableMenuItemId(menuItems);
            menuItem.Id = newId;

            menuItems.Add(menuItem);

            TextFileProcessor.SaveToMenuItemsFile(menuItems, MenuItemsFile);

            return menuItem;
        }

        private int FindNewAvailableMenuItemId(List<MenuItemModel> menuItems)
        {
            if (menuItems.Count == 0)
            {
                return 1;
            }

            return menuItems.OrderByDescending(menuItem => menuItem.Id).First().Id + 1;
        }
    }
}
