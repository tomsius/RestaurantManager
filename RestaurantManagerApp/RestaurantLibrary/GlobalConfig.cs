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

        /// <summary>
        /// Represents file name for MenuItemModel rows.
        /// </summary>
        public const string MenuItemsFile = "MenuItems.csv";

        /// <summary>
        /// Represents file name for OrderModel rows.
        /// </summary>
        public const string OrdersFile = "Orders.csv";

        /// <summary>
        /// Represents selected data storage type.
        /// </summary>
        public static IConnection Connection { get; private set; }

        /// <summary>
        /// Creates connection.
        /// </summary>
        public static void InitializeConnections()
        {
            TextFileConnector textConnector = new TextFileConnector();
            Connection = textConnector;
        }
    }
}
