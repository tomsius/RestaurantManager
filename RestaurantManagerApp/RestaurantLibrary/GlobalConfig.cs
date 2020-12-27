using RestaurantLibrary.Connections;
using System.Collections.Generic;

namespace RestaurantLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Represents file name for ProductModel rows.
        /// </summary>
        public const string ProductsFile = "Products.csv";
        public const string MenuItemsFile = "MenuItems.csv";
        public const string OrdersFile = "Orders.csv";

        public static IConnection Connection { get; private set; }

        public static void InitializeConnections()
        {
            // TODO - Set up Text Connector properly
            TextFileConnector textConnector = new TextFileConnector();
            Connection = textConnector;
        }
    }
}
