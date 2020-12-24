using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize connections
            RestaurantLibrary.GlobalConfig.InitializeConnections();

            //Application.Run(new RestaurantManagerForm());

            // TODO - Remove after done testing
            Application.Run(new AddProductForm());
        }
    }
}
