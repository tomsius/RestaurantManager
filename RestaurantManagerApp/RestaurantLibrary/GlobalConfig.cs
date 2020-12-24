using System.Collections.Generic;

namespace RestaurantLibrary
{
    public static class GlobalConfig
    {
        public static List<IConnection> Connections { get; private set; } = new List<IConnection>();

        public static void InitializeConnections()
        {
            // TODO - Set up Text Connector properly
            TextConnector textConnector = new TextConnector();
            Connections.Add(textConnector);
        }
    }
}
