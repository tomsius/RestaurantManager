using RestaurantLibrary.Connections;
using System.Collections.Generic;

namespace RestaurantLibrary
{
    public static class GlobalConfig
    {
        public static IConnection Connection { get; private set; }

        public static void InitializeConnections()
        {
            // TODO - Set up Text Connector properly
            TextFileConnector textConnector = new TextFileConnector();
            Connection = textConnector;
        }
    }
}
